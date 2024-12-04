using System;
using System.Reflection;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;

namespace EasyAbp.Abp.DynamicMenu.Localization
{
    public class DynamicMenuStringLocalizerProvider : IDynamicMenuStringLocalizerProvider, ITransientDependency
    {
        private readonly IStringLocalizerFactory _stringLocalizerFactory;

        public DynamicMenuStringLocalizerProvider(
            IStringLocalizerFactory stringLocalizerFactory)
        {
            _stringLocalizerFactory = stringLocalizerFactory;
        }
        
        public virtual async Task<IStringLocalizer> GetAsync(MenuItemDto menuItem)
        {
            var resourceType = await GetResourceTypeOrNullAsync(menuItem) ?? typeof(DynamicMenuResource);

            return _stringLocalizerFactory.Create(resourceType);
        }

        public virtual async Task<string> GetResourceNameAsync(MenuItemDto menuItem)
        {
            var resourceType = await GetResourceTypeOrNullAsync(menuItem) ?? typeof(DynamicMenuResource);

            return resourceType.GetCustomAttribute<LocalizationResourceNameAttribute>()!.Name;
        }

        public virtual Task<Type> GetResourceTypeOrNullAsync(MenuItemDto menuItem)
        {
            if (menuItem.LResourceTypeName.IsNullOrEmpty() || menuItem.LResourceTypeAssemblyName.IsNullOrEmpty())
            {
                return Task.FromResult<Type>(null);
            }

            try
            {
                return Task.FromResult(
                    Type.GetType($"{menuItem.LResourceTypeName}, {menuItem.LResourceTypeAssemblyName}", true));
            }
            catch
            {
                return Task.FromResult<Type>(null);
            }
        }
    }
}