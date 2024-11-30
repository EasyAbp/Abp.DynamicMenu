using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.BlobStoring.Database;
using EasyAbp.Abp.DynamicMenu.Demo.MultiTenancy;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;

namespace EasyAbp.Abp.DynamicMenu.Demo;

[DependsOn(typeof(AbpEmailingModule))]
[DependsOn(typeof(AbpAuditLoggingDomainModule))]
[DependsOn(typeof(AbpBackgroundJobsDomainModule))]
[DependsOn(typeof(AbpFeatureManagementDomainModule))]
[DependsOn(typeof(AbpIdentityDomainModule))]
[DependsOn(typeof(AbpIdentityServerDomainModule))]
[DependsOn(typeof(AbpPermissionManagementDomainIdentityServerModule))]
[DependsOn(typeof(AbpPermissionManagementDomainIdentityModule))]
[DependsOn(typeof(AbpSettingManagementDomainModule))]
[DependsOn(typeof(AbpTenantManagementDomainModule))]
[DependsOn(typeof(BlobStoringDatabaseDomainModule))]
//app modules
[DependsOn(typeof(DemoDomainSharedModule))]
public class DemoDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
        });

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
