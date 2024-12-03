using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using static EasyAbp.Abp.DynamicMenu.Permissions.DynamicMenuPermissions;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public interface IMenuItemAppService :
        ICrudAppService<
            MenuItemDto,
            string,
            GetMenuItemListInput,
            CreateMenuItemDto,
            UpdateMenuItemDto>
    {
    }
}