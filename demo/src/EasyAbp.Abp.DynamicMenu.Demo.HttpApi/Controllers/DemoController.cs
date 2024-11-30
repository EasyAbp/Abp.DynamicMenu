using EasyAbp.Abp.DynamicMenu.Demo.Localization;
using EasyAbp.Abp.DynamicMenu.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicMenu.Demo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class DemoController : AbpControllerBase
{
    protected DemoController()
    {
        LocalizationResource = typeof(DemoResource);
    }
}
