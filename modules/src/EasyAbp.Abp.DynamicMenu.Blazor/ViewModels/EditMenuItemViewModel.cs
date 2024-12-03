using System.ComponentModel.DataAnnotations;

namespace EasyAbp.Abp.DynamicMenu.Blazor.ViewModels
{
    public class EditMenuItemViewModel
    {
        [Display(Name = "MenuItemParentId")]
        public string ParentId { get; set; }

        [Display(Name = "MenuItemInAdministration")]
        public bool InAdministration { get; set; }

        [Display(Name = "MenuItemDisplayName")]
        public string DisplayName { get; set; }

        [Display(Name = "MenuItemUrl")]
        public string Url { get; set; }

        [Display(Name = "MenuItemUrlMvc")]
        public string UrlMvc { get; set; }

        [Display(Name = "MenuItemUrlBlazor")]
        public string UrlBlazor { get; set; }

        [Display(Name = "MenuItemUrlAngular")]
        public string UrlAngular { get; set; }

        [Display(Name = "MenuItemPermission")]
        public string Permission { get; set; }

        [Display(Name = "MenuItemOrder")]
        public int? Order { get; set; }

        [Display(Name = "MenuItemIcon")]
        public string Icon { get; set; }

        [Display(Name = "MenuItemTarget")]
        public string Target { get; set; }

        [Display(Name = "MenuItemIsDisabled")]
        public bool IsDisabled { get; set; }

        [Display(Name = "MenuItemLResourceTypeName")]
        public string LResourceTypeName { get; set; }

        [Display(Name = "MenuItemLResourceTypeAssemblyName")]
        public string LResourceTypeAssemblyName { get; set; }
    }
}