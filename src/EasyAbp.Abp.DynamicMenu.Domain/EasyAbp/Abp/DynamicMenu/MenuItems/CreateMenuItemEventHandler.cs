using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    [UnitOfWork(true)]
    public class CreateMenuItemEventHandler :
        IDistributedEventHandler<TryCreateMenuItemEto>,
        IDistributedEventHandler<TryCreateMenuItemsEto>,
        ITransientDependency
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public CreateMenuItemEventHandler(
            IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public virtual async Task HandleEventAsync(TryCreateMenuItemEto eventData)
        {
            var menuItem = await _menuItemRepository.FindAsync(x => x.Name == eventData.Name);

            if (menuItem != null)
            {
                return;
            }

            menuItem = new MenuItem(
                eventData.ParentName,
                eventData.InAdministration,
                eventData.Name,
                eventData.DisplayName,
                eventData.Url,
                eventData.UrlMvc,
                eventData.UrlBlazor,
                eventData.UrlAngular,
                eventData.Permission,
                eventData.Order,
                eventData.Icon,
                eventData.Target,
                eventData.IsDisabled,
                eventData.LResourceTypeName,
                eventData.LResourceTypeAssemblyName,
                null);

            eventData.MapExtraPropertiesTo(menuItem);

            await _menuItemRepository.InsertAsync(menuItem, true);
        }

        public virtual async Task HandleEventAsync(TryCreateMenuItemsEto eventData)
        {
            foreach (var eto in eventData.Items)
            {
                await HandleEventAsync(eto);
            }
        }
    }
}
