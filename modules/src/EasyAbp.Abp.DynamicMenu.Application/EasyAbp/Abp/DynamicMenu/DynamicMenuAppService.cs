using EasyAbp.Abp.DynamicMenu.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicMenu
{
    public abstract class DynamicMenuAppService : ApplicationService
    {
        protected DynamicMenuAppService()
        {
            LocalizationResource = typeof(DynamicMenuResource);
            ObjectMapperContext = typeof(AbpDynamicMenuApplicationModule);
        }
    }
}
