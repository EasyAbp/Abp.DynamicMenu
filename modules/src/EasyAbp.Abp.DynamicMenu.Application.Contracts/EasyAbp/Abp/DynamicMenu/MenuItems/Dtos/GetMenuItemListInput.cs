using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.Abp.DynamicMenu.MenuItems.Dtos
{
    public class GetMenuItemListInput : PagedAndSortedResultRequestDto
    {
        public string ParentId { get; set; }
        //public Func<string, Task> ParentIdChanged { get; set; }
    }
}