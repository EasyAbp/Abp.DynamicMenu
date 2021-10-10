using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(DynamicMenuDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class DynamicMenuApplicationContractsModule : AbpModule
    {

    }
}
