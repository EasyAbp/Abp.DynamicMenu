using EasyAbp.Abp.DynamicMenu.MenuItems;
using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.Abp.DynamicMenu.EntityFrameworkCore
{
    public static class DynamicMenuDbContextModelCreatingExtensions
    {
        public static void ConfigureAbpDynamicMenu(
            this ModelBuilder builder,
            Action<DynamicMenuModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DynamicMenuModelBuilderConfigurationOptions(
                DynamicMenuDbProperties.DbTablePrefix,
                DynamicMenuDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */


            builder.Entity<MenuItem>(b =>
            {
                b.ToTable(options.TablePrefix + "MenuItems", options.Schema);
                b.ConfigureByConvention();

                /* Configure more properties here */
                
                b.HasKey(e => new
                {
                    e.Name,
                });

                b.HasMany(x => x.MenuItems).WithOne();
            });
        }
    }
}
