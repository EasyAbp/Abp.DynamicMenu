using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.Localization;
using EasyAbp.Abp.DynamicMenu.MenuItems;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using EasyAbp.Abp.DynamicMenu.Permissions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization;
using Volo.Abp.Security.Claims;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Abp.DynamicMenu.Blazor.Menus
{
    public static class IdentityExtensions
    {
        /// <summary>
        ///     Return the user id using the UserIdClaimType
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static T GetUserId<T>(this IIdentity identity) where T : IConvertible
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                var id = ci.FindFirst("sub");
                if (id != null)
                {
                    return (T)Convert.ChangeType(id.Value, typeof(T), CultureInfo.InvariantCulture);
                }
            }
            return default(T);
        }
    }
    public class DynamicMenuMenuContributor : IMenuContributor
    {
        private ILogger<DynamicMenuMenuContributor> _logger;
        private IAbpAuthorizationPolicyProvider _policyProvider;
        private ICurrentPrincipalAccessor _currentPrincipalAccessor;
        private IMenuItemAppService _menuItemAppService;
        private IDynamicMenuStringLocalizerProvider _stringLocalizerProvider;

        private Dictionary<string, StringLocalizerModel> ModuleNameStringLocalizers { get; set; } = new();
        private string userId;
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            var loggerFactory = context.ServiceProvider.GetRequiredService<ILoggerFactory>();
            _logger = loggerFactory.CreateLogger<DynamicMenuMenuContributor>();
            _policyProvider = context.ServiceProvider.GetRequiredService<IAbpAuthorizationPolicyProvider>();
            _currentPrincipalAccessor = context.ServiceProvider.GetRequiredService<ICurrentPrincipalAccessor>();
            _menuItemAppService = context.ServiceProvider.GetRequiredService<IMenuItemAppService>();
            _stringLocalizerProvider =
                context.ServiceProvider.GetRequiredService<IDynamicMenuStringLocalizerProvider>();
            var id = _currentPrincipalAccessor.Principal.Identity;
            if (id != null)
            {
                userId = _currentPrincipalAccessor.Principal.Identity.GetUserId<string>();
            }
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        protected virtual async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var menuItems = await _menuItemAppService.GetListAsync(new GetMenuItemListInput
            {
                MaxResultCount = LimitedResultRequestDto.MaxMaxResultCount,
                ParentId = null
            });

            await AddDynamicMenuItemsAsync(menuItems.Items, context);
            await AddDynamicMenuManagementMenuItemAsync(context);
        }

        protected virtual async Task AddDynamicMenuManagementMenuItemAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<DynamicMenuResource>();

            var dynamicMenu = new ApplicationMenuItem(DynamicMenuMenus.Prefix, displayName: l["Menu:DynamicMenu"],
                "~/Abp/DynamicMenu", icon: "fa fa-bars");

            if (await context.IsGrantedAsync(DynamicMenuPermissions.MenuItem.Default))
            {
                dynamicMenu.AddItem(
                    new ApplicationMenuItem(DynamicMenuMenus.MenuItem, l["Menu:MenuItem"],
                        "~/Abp/DynamicMenu/MenuItems/MenuItem")
                );
            }

            if (dynamicMenu.Items.Any())
            {
                context.Menu.GetAdministration().AddItem(dynamicMenu);
            }
        }

        protected virtual async Task AddDynamicMenuItemsAsync(IReadOnlyCollection<MenuItemDto> menuItems,
            MenuConfigurationContext context)
        {
            await AddDynamicMenuItemsAsync(context.Menu,
                menuItems.Where(x => !x.InAdministration), context);

            await AddDynamicMenuItemsAsync(context.Menu.GetAdministration(),
                menuItems.Where(x => x.InAdministration && x.IsPublic), context);
            //get non public menus
            await AddDynamicMenuItemsAsync(context.Menu.GetAdministration(),
                menuItems.Where(x => x.InAdministration && !x.IsPublic && x.CreatorId.ToString() == userId), context);
        }

        protected virtual async Task AddDynamicMenuItemsAsync(IHasMenuItems parent, IEnumerable<MenuItemDto> menuItems,
            MenuConfigurationContext context)
        {
            foreach (var menuItem in menuItems.Where(x => !x.IsDisabled))
            {
                if (!await IsFoundAndGrantedAsync(menuItem.Permission, menuItem.CreatorId == null ? null : menuItem.CreatorId.ToString(), menuItem.IsPublic, context))
                {
                    continue;
                }

                var l = await GetOrCreateStringLocalizerAsync(menuItem, _stringLocalizerProvider);

                var child = new ApplicationMenuItem(menuItem.Id, l[menuItem.DisplayName],
                    order: menuItem.Order ?? default, icon: menuItem.Icon);

                if (menuItem.MenuItems.IsNullOrEmpty())
                {
                    child.Url = menuItem.UrlBlazor ?? menuItem.Url;
                    child.Target = menuItem.Target;
                }
                else
                {
                    await AddDynamicMenuItemsAsync(child, menuItem.MenuItems, context);
                }

                parent.Items.Add(child);
            }
        }

        protected virtual async Task<bool> IsFoundAndGrantedAsync(string policyName, string creatorId, bool isPublic, MenuConfigurationContext context)
        {
            if (policyName != null)
            {
                var policy = await _policyProvider.GetPolicyAsync(policyName);

                if (policy == null)
                {
                    _logger.LogWarning($"[Entity UI] No policy found: {policyName}.");

                    return false;
                }

                return (await context.AuthorizationService.AuthorizeAsync(
                    _currentPrincipalAccessor.Principal,
                    null,
                    policyName)).Succeeded;
            }

            if (!isPublic && creatorId != null)
            {
                return creatorId == userId;

            }
            return creatorId == null ? true : isPublic;
        }

        protected virtual async Task<IStringLocalizer> GetOrCreateStringLocalizerAsync(MenuItemDto menuItem,
            IDynamicMenuStringLocalizerProvider stringLocalizerProvider)
        {
            if (ModuleNameStringLocalizers.ContainsKey(menuItem.Id) &&
                ModuleNameStringLocalizers[menuItem.Id].LResourceTypeName == menuItem.LResourceTypeName &&
                ModuleNameStringLocalizers[menuItem.Id].LResourceTypeAssemblyName ==
                menuItem.LResourceTypeAssemblyName)
            {
                return ModuleNameStringLocalizers[menuItem.Id].StringLocalizer;
            }

            var localizer = await stringLocalizerProvider.GetAsync(menuItem);

            ModuleNameStringLocalizers[menuItem.Id] = new StringLocalizerModel
            {
                LResourceTypeName = menuItem.LResourceTypeName,
                LResourceTypeAssemblyName = menuItem.LResourceTypeAssemblyName,
                StringLocalizer = localizer
            };

            return localizer;
        }
    }
}