using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicMenu.MenuItems.Dtos
{
    public class GetMenuItemListInput : PagedAndSortedResultRequestDto
    {
        public string ParentName { get; set; }
    }
}