using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(DynamicMenuApplicationModule),
        typeof(DynamicMenuDomainTestModule)
        )]
    public class DynamicMenuApplicationTestModule : AbpModule
    {

    }
}
