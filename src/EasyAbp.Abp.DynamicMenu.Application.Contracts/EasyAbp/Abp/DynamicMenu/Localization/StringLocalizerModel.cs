using Microsoft.Extensions.Localization;

namespace EasyAbp.Abp.DynamicMenu.Localization
{
    public class StringLocalizerModel
    {
        public string LResourceTypeName { get; set; }
        
        public string LResourceTypeAssemblyName { get; set; }
        
        public IStringLocalizer StringLocalizer { get; set; }
    }
}