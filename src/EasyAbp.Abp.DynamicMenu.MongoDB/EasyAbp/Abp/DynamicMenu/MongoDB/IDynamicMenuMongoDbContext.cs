using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicMenu.MongoDB
{
    [ConnectionStringName(DynamicMenuDbProperties.ConnectionStringName)]
    public interface IDynamicMenuMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; set; }
         */
    }
}
