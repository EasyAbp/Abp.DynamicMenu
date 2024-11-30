using Syrna.Demo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu.Demo
{
    [DependsOn(
        typeof(DemoEntityFrameworkCoreModule),
        typeof(DemoApplicationModule)
    )]
    public class DynamicMenuDemoHostSharedModule : AbpModule
    {

    }
}
