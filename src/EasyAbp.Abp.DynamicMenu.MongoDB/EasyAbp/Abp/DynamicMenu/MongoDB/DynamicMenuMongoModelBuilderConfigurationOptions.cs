using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicMenu.MongoDB
{
    public class DynamicMenuMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public DynamicMenuMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}