using System;
using System.ComponentModel;
namespace EasyAbp.Abp.DynamicMenu.MenuItems.Dtos
{
    [Serializable]
    public class UpdateMenuItemDto
    {
        public string ParentName { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }
        
        public string UrlMvc { get; set; }
        
        public string UrlBlazor { get; set; }
        
        public string UrlAngular { get; set; }
        
        public string Permission { get; set; }

        public string LResourceTypeName { get; set; }

        public string LResourceTypeAssemblyName { get; set; }
    }
}