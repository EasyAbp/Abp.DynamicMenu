using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpDddDomainModule),
        typeof(AbpDynamicMenuDomainSharedModule)
    )]
    public class AbpDynamicMenuDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpDynamicMenuDomainModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicMenuDomainModule>(validate: true);
            });
        }
    }
}
