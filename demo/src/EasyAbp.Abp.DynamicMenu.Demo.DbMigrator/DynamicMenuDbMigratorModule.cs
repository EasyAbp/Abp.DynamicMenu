using EasyAbp.Abp.DynamicMenu.Demo.SqlServer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
//using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu.Demo.DbMigrator;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(DemoEntityFrameworkCoreSqlServerModule))]
[DependsOn(typeof(AbpDynamicMenuApplicationContractsModule))]
public class DynamicMenuDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also LayoutMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer(x => x.UseCompatibilityLevel(120));
        });
    }
}
