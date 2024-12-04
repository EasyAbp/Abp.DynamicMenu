using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using EasyAbp.Abp.DynamicMenu.EntityFrameworkCore;

namespace EasyAbp.Abp.DynamicMenu.Demo.SqlServer.EntityFrameworkCore;

/* This DbContext is only used for database migrations.
     * It is not used on runtime. See LayoutDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
public class DemoMigrationsDbContext(DbContextOptions<DemoMigrationsDbContext> options)
    : AbpDbContext<DemoMigrationsDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        //builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        //builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside the ConfigureLayout method */

        builder.ConfigureAbpDynamicMenu();
    }
}