using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using EasyAbp.Abp.DynamicMenu.Blazor;
using Volo.Abp.AspNetCore.Components.Web.Theming;

namespace EasyAbp.Abp.DynamicMenu.Demo.Blazor;

[DependsOn(typeof(AbpAutoMapperModule))]
[DependsOn(typeof(AbpAspNetCoreComponentsWebThemingModule))]
//app modules
[DependsOn(typeof(DemoApplicationContractsModule))]
[DependsOn(typeof(AbpDynamicMenuBlazorModule))]

public class DemoBlazorModule : AbpModule
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<DemoBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<DemoBlazorAutoMapperProfile>(validate: true);
        });

        //Configure<AbpNavigationOptions>(options =>
        //{
        //    options.MenuContributors.Add(new DemoMenuContributor());
        //});

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(DemoBlazorModule).Assembly);
        });
    }
}
