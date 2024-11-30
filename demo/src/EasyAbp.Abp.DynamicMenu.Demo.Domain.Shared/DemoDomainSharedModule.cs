using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.BlobStoring.Database;
using EasyAbp.Abp.DynamicMenu.Demo.Localization;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.PermissionManagement;

namespace EasyAbp.Abp.DynamicMenu.Demo;

[DependsOn(typeof(AbpAuditLoggingDomainSharedModule))]
[DependsOn(typeof(AbpBackgroundJobsDomainSharedModule))]
[DependsOn(typeof(AbpFeatureManagementDomainSharedModule))]
[DependsOn(typeof(AbpIdentityDomainSharedModule))]
[DependsOn(typeof(AbpIdentityServerDomainSharedModule))]
[DependsOn(typeof(AbpPermissionManagementDomainSharedModule))]
[DependsOn(typeof(AbpSettingManagementDomainSharedModule))]
[DependsOn(typeof(AbpTenantManagementDomainSharedModule))]
[DependsOn(typeof(BlobStoringDatabaseDomainSharedModule))]
//app modules
[DependsOn(typeof(AbpDynamicMenuDomainSharedModule))]
public class DemoDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        DemoGlobalFeatureConfigurator.Configure();
        DemoModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<DemoDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<DemoResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Alpha");

            options.DefaultResourceType = typeof(DemoResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Alpha", typeof(DemoResource));
        });
    }
}
