using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.Abp.DynamicMenu.MenuItems;

namespace EasyAbp.Abp.DynamicMenu.EntityFrameworkCore
{
    [ConnectionStringName(DynamicMenuDbProperties.ConnectionStringName)]
    public interface IDemoDbContext : IEfCoreDbContext
    {
    }
}
