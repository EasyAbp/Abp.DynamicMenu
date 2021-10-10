using EasyAbp.Abp.DynamicMenu.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicMenu
{
    public abstract class DynamicMenuController : AbpController
    {
        protected DynamicMenuController()
        {
            LocalizationResource = typeof(DynamicMenuResource);
        }
    }
}
