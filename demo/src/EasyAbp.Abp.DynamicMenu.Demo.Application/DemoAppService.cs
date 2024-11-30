using EasyAbp.Abp.DynamicMenu.Demo.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicMenu.Demo;

/* Inherit your application services from this class.
 */
public abstract class DemoAppService : ApplicationService
{
    protected DemoAppService()
    {
        LocalizationResource = typeof(DemoResource);
    }
}
