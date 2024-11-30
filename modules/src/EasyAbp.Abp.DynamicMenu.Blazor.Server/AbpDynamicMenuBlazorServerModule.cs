using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(AbpDynamicMenuBlazorModule)
        )]
    public class AbpDynamicMenuBlazorServerModule : AbpModule
    {
        
    }
}