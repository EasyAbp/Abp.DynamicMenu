using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpDynamicMenuApplicationModule),
        typeof(DynamicMenuDomainTestModule)
        )]
    public class DynamicMenuApplicationTestModule : AbpModule
    {

    }
}
