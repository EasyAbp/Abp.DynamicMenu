using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AbpDynamicMenuBlazorModule),
        typeof(AbpDynamicMenuHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class AbpDynamicMenuBlazorWebAssemblyModule : AbpModule
    {
        
    }
}