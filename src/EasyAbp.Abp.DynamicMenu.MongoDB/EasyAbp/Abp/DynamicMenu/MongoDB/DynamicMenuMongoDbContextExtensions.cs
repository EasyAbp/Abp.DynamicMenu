using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.Abp.DynamicMenu.MongoDB
{
    public static class DynamicMenuMongoDbContextExtensions
    {
        public static void ConfigureDynamicMenu(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DynamicMenuMongoModelBuilderConfigurationOptions(
                DynamicMenuDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}