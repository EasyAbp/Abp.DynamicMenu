using Microsoft.Extensions.DependencyInjection;
using EasyAbp.Abp.DynamicMenu.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Abp.DynamicMenu.Blazor
{
    [DependsOn(
        typeof(DynamicMenuApplicationContractsModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule)
        )]
    public class DynamicMenuBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<DynamicMenuBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<DynamicMenuBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DynamicMenuMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(DynamicMenuBlazorModule).Assembly);
            });
        }
    }
}