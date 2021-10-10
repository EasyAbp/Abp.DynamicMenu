using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.Abp.DynamicMenu.MenuItems;

namespace EasyAbp.Abp.DynamicMenu.EntityFrameworkCore
{
    [ConnectionStringName(DynamicMenuDbProperties.ConnectionStringName)]
    public interface IDynamicMenuDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<MenuItem> MenuItems { get; set; }
    }
}
