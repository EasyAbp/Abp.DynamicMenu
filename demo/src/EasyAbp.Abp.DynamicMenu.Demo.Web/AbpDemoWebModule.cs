using EasyAbp.Abp.DynamicMenu.Demo.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using EasyAbp.Abp.DynamicMenu.Localization;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using EasyAbp.Abp.DynamicMenu.Permissions;
using Volo.Abp.Account.Web;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity.Web;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.TenantManagement.Web;
using EasyAbp.Abp.DynamicMenu.Web;

namespace EasyAbp.Abp.DynamicMenu.Demo.Web
{
    [DependsOn(typeof(DemoApplicationContractsModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpAccountWebModule))]
    [DependsOn(typeof(AbpSettingManagementWebModule))]
    [DependsOn(typeof(AbpIdentityWebModule))]
    [DependsOn(typeof(AbpFeatureManagementWebModule))]
    [DependsOn(typeof(AbpTenantManagementWebModule))]
    [DependsOn(typeof(AbpDynamicMenuWebModule))]
    public class AbpDemoWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(DemoResource), typeof(AbpDemoWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpDemoWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //Configure<AbpNavigationOptions>(options =>
            //{
            //    options.MenuContributors.Add(new DemoMenuContributor());
            //});

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpDemoWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<AbpDemoWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDemoWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
        }
    }
}
