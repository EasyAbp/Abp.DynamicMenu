using EasyAbp.Abp.DynamicMenu.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(DynamicMenuEntityFrameworkCoreTestModule)
        )]
    public class DynamicMenuDomainTestModule : AbpModule
    {
        
    }
}
