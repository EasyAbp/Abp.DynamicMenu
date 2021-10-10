using EasyAbp.Abp.DynamicMenu.Localization;
using Volo.Abp.AspNetCore.Components;

namespace EasyAbp.Abp.DynamicMenu.Blazor.Server.Host
{
    public abstract class DynamicMenuComponentBase : AbpComponentBase
    {
        protected DynamicMenuComponentBase()
        {
            LocalizationResource = typeof(DynamicMenuResource);
        }
    }
}
