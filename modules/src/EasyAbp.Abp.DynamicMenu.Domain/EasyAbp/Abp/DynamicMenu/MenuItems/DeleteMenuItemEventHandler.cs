using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    [UnitOfWork]
    public class DeleteMenuItemEventHandler :
        IDistributedEventHandler<TryDeleteMenuItemEto>,
        ITransientDependency
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public DeleteMenuItemEventHandler(
            IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }
        
        public virtual async Task HandleEventAsync(TryDeleteMenuItemEto eventData)
        {
            var menuItem = await _menuItemRepository.FindAsync(x => x.Id == eventData.Id);

            if (menuItem == null)
            {
                return;
            }

            await _menuItemRepository.DeleteAsync(menuItem, true);
        }
    }
}