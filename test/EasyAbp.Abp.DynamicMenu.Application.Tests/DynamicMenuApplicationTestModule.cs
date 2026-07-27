using EasyAbp.Abp.DynamicMenu.MenuItems;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpDynamicMenuApplicationModule),
        typeof(DynamicMenuDomainTestModule)
        )]
    public class DynamicMenuApplicationTestModule : AbpModule
    {
        private static readonly OneTimeRunner OneTimeRunner = new();

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            /* Extra properties are only mapped when they are defined for the
             * source and destination types, so define one to test the mapping. */
            OneTimeRunner.Run(() =>
            {
                ObjectExtensionManager.Instance
                    .AddOrUpdateProperty<MenuItem, string>("CustomKey")
                    .AddOrUpdateProperty<MenuItemDto, string>("CustomKey");
            });
        }
    }
}
