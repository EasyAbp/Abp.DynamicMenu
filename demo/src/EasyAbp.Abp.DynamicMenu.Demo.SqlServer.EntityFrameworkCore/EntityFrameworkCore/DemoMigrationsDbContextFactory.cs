using System.IO;
using EasyAbp.Abp.DynamicMenu.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.Abp.DynamicMenu.Demo.SqlServer.EntityFrameworkCore;

/* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
public class DemoMigrationsDbContextFactory : IDesignTimeDbContextFactory<DemoMigrationsDbContext>
{
    public DemoMigrationsDbContext CreateDbContext(string[] args)
    {
        DemoEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<DemoMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new DemoMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EasyAbp.Abp.DynamicMenu.Demo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
