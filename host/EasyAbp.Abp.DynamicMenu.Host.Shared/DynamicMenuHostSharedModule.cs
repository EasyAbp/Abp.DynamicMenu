using EasyAbp.Abp.DynamicMenu.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(DynamicMenuEntityFrameworkCoreModule),
        typeof(DynamicMenuApplicationModule)
    )]
    public class DynamicMenuHostSharedModule : AbpModule
    {
        
    }
}
