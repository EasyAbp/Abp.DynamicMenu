using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu.Demo.Blazor.WebAssembly;

[DependsOn(
    typeof(DemoBlazorModule)
)]
public class DemoBlazorWebAssemblyModule : AbpModule
{
}
