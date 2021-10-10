using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(DynamicMenuDomainSharedModule)
    )]
    public class DynamicMenuDomainModule : AbpModule
    {

    }
}
