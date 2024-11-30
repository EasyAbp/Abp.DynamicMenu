using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.AuditLogging;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(AbpDynamicMenuDomainSharedModule))]
    [DependsOn(typeof(AbpAuditLoggingDomainModule))]
    [DependsOn(typeof(AbpFeatureManagementDomainModule))]
    [DependsOn(typeof(AbpIdentityDomainModule))]
    [DependsOn(typeof(AbpIdentityServerDomainModule))]
    [DependsOn(typeof(AbpPermissionManagementDomainIdentityServerModule))]
    [DependsOn(typeof(AbpPermissionManagementDomainIdentityModule))]
    [DependsOn(typeof(AbpSettingManagementDomainModule))]
    [DependsOn(typeof(AbpTenantManagementDomainModule))]
    [DependsOn(typeof(AbpEmailingModule))]
    public class AbpDynamicMenuDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AbpDynamicMenuDomainModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDynamicMenuDomainModule>(validate: false); // todo: https://github.com/abpframework/abp/issues/15404
            });
#if DEBUG
            context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
        }
    }
}
