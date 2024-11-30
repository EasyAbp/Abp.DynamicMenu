using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using EasyAbp.Abp.DynamicMenu.Localization;
using EasyAbp.Abp.DynamicMenu.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using EasyAbp.Abp.DynamicMenu.Permissions;

namespace EasyAbp.Abp.DynamicMenu.Web
{
    [DependsOn(
        typeof(AbpDynamicMenuApplicationContractsModule),
        typeof(AbpAspNetCoreMvcUiThemeSharedModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpDynamicMenuWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(DynamicMenuResource), typeof(AbpDynamicMenuWebModule).Assembly);
            });

            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpDynamicMenuWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new DynamicMenuMenuContributor());
            });

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpDynamicMenuWebModule>();
            });

            context.Services.AddAutoMapperObjectMapper<AbpDynamicMenuWebModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicMenuWebModule>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
        }
    }
}
