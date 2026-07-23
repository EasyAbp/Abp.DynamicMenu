using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Mapperly;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpMapperlyModule),
        typeof(AbpDddDomainModule),
        typeof(AbpDynamicMenuDomainSharedModule)
    )]
    public class AbpDynamicMenuDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMapperlyObjectMapper<AbpDynamicMenuDomainModule>();
        }
    }
}
