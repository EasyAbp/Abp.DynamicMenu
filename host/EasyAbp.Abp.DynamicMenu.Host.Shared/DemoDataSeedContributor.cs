using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.MenuItems;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;

namespace EasyAbp.Abp.DynamicMenu
{
    public class DemoDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public DemoDataSeedContributor(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }
        
        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _menuItemRepository.FindAsync(x => x.Name == "DemoMenu") != null)
            {
                return;
            }

            var subItems = new List<MenuItem>
            {
                new("DemoMenu", "ChangePassword", "Change password", "~/Account/Manage", null, null, null, null,
                    DynamicMenuConsts.DefaultLResourceTypeName, DynamicMenuConsts.DefaultLResourceTypeAssemblyName,
                    null)
            };
            
            var demoMenu = new MenuItem(null, "DemoMenu", "Demo menu", null, null, null, null, null,
                DynamicMenuConsts.DefaultLResourceTypeName, DynamicMenuConsts.DefaultLResourceTypeAssemblyName, subItems);
            
            await _menuItemRepository.InsertAsync(demoMenu, true);
        }
    }
}