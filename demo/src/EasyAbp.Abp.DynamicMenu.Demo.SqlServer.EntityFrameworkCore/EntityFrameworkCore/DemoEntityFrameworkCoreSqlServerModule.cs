using EasyAbp.Abp.DynamicMenu.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu.Demo.SqlServer.EntityFrameworkCore;

[DependsOn(typeof(DemoEntityFrameworkCoreModule))]
public class DemoEntityFrameworkCoreSqlServerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<DemoMigrationsDbContext>();
    }
}