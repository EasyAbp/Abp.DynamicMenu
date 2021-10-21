using EasyAbp.Abp.DynamicMenu.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpDynamicMenuEntityFrameworkCoreModule),
        typeof(AbpDynamicMenuApplicationModule)
    )]
    public class DynamicMenuHostSharedModule : AbpModule
    {
        
    }
}
