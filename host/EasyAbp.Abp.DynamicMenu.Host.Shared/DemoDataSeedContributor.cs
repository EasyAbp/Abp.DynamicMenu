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

            var demoMenu = new MenuItem(null, false, "DemoMenu", "Demo menu", null, null, null, null, null,
                DynamicMenuConsts.DefaultLResourceTypeName, DynamicMenuConsts.DefaultLResourceTypeAssemblyName,
                new List<MenuItem>
                {
                    new("DemoMenu", false, "ChangePassword", "Change password", "~/Account/Manage", null, null, null,
                        null, DynamicMenuConsts.DefaultLResourceTypeName,
                        DynamicMenuConsts.DefaultLResourceTypeAssemblyName, null)
                });

            await _menuItemRepository.InsertAsync(demoMenu, true);

            var demoMenu2 = new MenuItem(null, true, "DemoMenu2", "Demo menu 2", null, null, null, null, null,
                DynamicMenuConsts.DefaultLResourceTypeName, DynamicMenuConsts.DefaultLResourceTypeAssemblyName,
                new List<MenuItem>
                {
                    new("DemoMenu2", false, "Google", "Google", "https://google.com", null, null, null, null,
                        DynamicMenuConsts.DefaultLResourceTypeName, DynamicMenuConsts.DefaultLResourceTypeAssemblyName,
                        null)
                });

            await _menuItemRepository.InsertAsync(demoMenu2, true);
        }
    }
}