using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace EasyAbp.Abp.DynamicMenu.Demo;

[DependsOn(typeof(DemoDomainModule))]
[DependsOn(typeof(DemoApplicationContractsModule))]

[DependsOn(typeof(AbpAccountApplicationModule))]
[DependsOn(typeof(AbpIdentityApplicationModule))]
[DependsOn(typeof(AbpPermissionManagementApplicationModule))]
[DependsOn(typeof(AbpTenantManagementApplicationModule))]
[DependsOn(typeof(AbpFeatureManagementApplicationModule))]
[DependsOn(typeof(AbpSettingManagementApplicationModule))]
//app modules
[DependsOn(typeof(AbpDynamicMenuApplicationModule))]
public class DemoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<DemoApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<DemoApplicationModule>();
        });
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<DemoApplicationAutoMapperProfile>(validate: true);
        });
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<DemoApplicationModule>();
        });
    }
}
