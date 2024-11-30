using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.Abp.DynamicMenu.MenuItems;

namespace EasyAbp.Abp.DynamicMenu.EntityFrameworkCore
{
    [ConnectionStringName(DynamicMenuDbProperties.ConnectionStringName)]
    public class DemoMigrationsDbContext : AbpDbContext<DemoMigrationsDbContext>, IDynamicMenuDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<MenuItem> MenuItems { get; set; }

        public DemoMigrationsDbContext(DbContextOptions<DemoMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAbpDynamicMenu();
        }
    }
}
