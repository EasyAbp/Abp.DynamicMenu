using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    [UnitOfWork(true)]
    public class CreateMenuItemEventHandler :
        IDistributedEventHandler<TryCreateMenuItemEto>,
        IDistributedEventHandler<TryCreateMenuItemsEto>,
        ITransientDependency
    {
        private readonly IObjectMapper _objectMapper;
        private readonly IMenuItemRepository _menuItemRepository;

        public CreateMenuItemEventHandler(
            IObjectMapper<AbpDynamicMenuDomainModule> objectMapper,
            IMenuItemRepository menuItemRepository)
        {
            _objectMapper = objectMapper;
            _menuItemRepository = menuItemRepository;
        }
        
        public virtual async Task HandleEventAsync(TryCreateMenuItemEto eventData)
        {
            var menuItem = await _menuItemRepository.FindAsync(x => x.Name == eventData.Name);

            if (menuItem != null)
            {
                return;
            }

            menuItem = _objectMapper.Map<TryCreateMenuItemEto, MenuItem>(eventData);
            
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