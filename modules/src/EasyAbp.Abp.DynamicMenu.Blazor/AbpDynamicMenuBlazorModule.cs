using EasyAbp.Abp.DynamicMenu.Blazor.Menus;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.Abp.DynamicMenu.Blazor
{
    [DependsOn(
        typeof(AbpDynamicMenuApplicationContractsModule),
        typeof(AbpAspNetCoreComponentsWebThemingModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpDynamicMenuBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.AddAutoMapperObjectMapper<AbpDynamicMenuBlazorModule>();

            //Configure<AbpAutoMapperOptions>(options =>
            //{
            //    options.AddProfile<DynamicMenuBlazorAutoMapperProfile>(validate: true);
            //});

            context.Services.AddAutoMapperObjectMapper<AbpDynamicMenuBlazorModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicMenuBlazorModule>(validate: true);
            });
            
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DynamicMenuMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AbpDynamicMenuBlazorModule).Assembly);
            });
        }
    }
}