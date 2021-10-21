using EasyAbp.Abp.DynamicMenu.MenuItems;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpDynamicMenuDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AbpDynamicMenuEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<DynamicMenuDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<MenuItem, MenuItemRepository>();
            });
        }
    }
}
