using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicMenu.MongoDB
{
    [ConnectionStringName(DynamicMenuDbProperties.ConnectionStringName)]
    public class DynamicMenuMongoDbContext : AbpMongoDbContext, IDynamicMenuMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureDynamicMenu();
        }
    }
}