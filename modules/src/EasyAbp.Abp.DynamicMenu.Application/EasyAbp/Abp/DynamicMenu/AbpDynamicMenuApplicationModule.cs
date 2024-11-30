using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpDynamicMenuDomainModule),
        typeof(AbpDynamicMenuApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpDynamicMenuApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpDynamicMenuApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicMenuApplicationModule>(validate: false); // todo: https://github.com/abpframework/abp/issues/15404
            });
        }
    }
}
