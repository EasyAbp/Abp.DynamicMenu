using Volo.Abp.Modularity;

namespace EasyAbp.Abp.DynamicMenu.Demo.Blazor.Server;

[DependsOn(
    typeof(DemoBlazorModule)
)]
public class DemoBlazorServerModule : AbpModule
{

}
