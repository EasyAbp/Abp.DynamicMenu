using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpDynamicMenuApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AbpDynamicMenuHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "EasyAbpAbpDynamicMenu";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AbpDynamicMenuApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
