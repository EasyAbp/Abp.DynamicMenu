using System;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.Abp.DynamicMenu.MenuItems.Dtos
{
    public abstract class CreateOrUpdateMenuItemDto : ExtensibleObject
    {
        public string Id { get; set; }
               
        public string ParentId { get; set; }

        public bool InAdministration { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string UrlMvc { get; set; }

        public string UrlBlazor { get; set; }

        public string UrlAngular { get; set; }

        public string Permission { get; set; }

        public int? Order { get; set; }

        public string Icon { get; set; }

        public string Target { get; set; }

        public bool IsPublic { get; set; }

        public bool IsDisabled { get; set; }

        public string LResourceTypeName { get; set; }

        public string LResourceTypeAssemblyName { get; set; }
        
        protected CreateOrUpdateMenuItemDto()
            : base(setDefaultsForExtraProperties: false)
        {
        }
    }
}