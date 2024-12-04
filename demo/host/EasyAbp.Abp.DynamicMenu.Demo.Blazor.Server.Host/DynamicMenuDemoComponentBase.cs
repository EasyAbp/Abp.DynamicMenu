using EasyAbp.Abp.DynamicMenu.Demo.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EasyAbp.Abp.DynamicMenu.Demo.Blazor.Server.Host
{
    public abstract class DynamicMenuDemoComponentBase : AbpComponentBase
    {
        protected DynamicMenuDemoComponentBase()
        {
            LocalizationResource = typeof(DemoResource);
        }
    }
}
