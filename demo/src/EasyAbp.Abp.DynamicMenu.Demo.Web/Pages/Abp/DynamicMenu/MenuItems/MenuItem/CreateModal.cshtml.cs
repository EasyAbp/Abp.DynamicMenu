using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.MenuItems;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using EasyAbp.Abp.DynamicMenu.Web.Pages.Abp.DynamicMenu.MenuItems.MenuItem.ViewModels;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicMenu.Web.Pages.Abp.DynamicMenu.MenuItems.MenuItem
{
    public class CreateModalModel : DynamicMenuPageModel
    {
        [BindProperty]
        public CreateMenuItemViewModel ViewModel { get; set; } = new();

        private readonly IMenuItemAppService _service;

        public CreateModalModel(IMenuItemAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync([CanBeNull] string parentName)
        {
            ViewModel.ParentName = parentName;
            ViewModel.LResourceTypeName = DynamicMenuConsts.DefaultLResourceTypeName;
            ViewModel.LResourceTypeAssemblyName = DynamicMenuConsts.DefaultLResourceTypeAssemblyName;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateMenuItemViewModel, CreateMenuItemDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}