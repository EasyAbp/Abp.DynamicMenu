using System.Threading.Tasks;

namespace EasyAbp.Abp.DynamicMenu.Demo.Data;

public interface IDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
