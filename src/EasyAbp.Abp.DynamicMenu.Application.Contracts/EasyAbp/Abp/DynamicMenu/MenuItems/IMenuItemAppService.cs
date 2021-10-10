using System;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public interface IMenuItemAppService :
        ICrudAppService< 
            MenuItemDto, 
            MenuItemKey, 
            GetMenuItemListInput,
            CreateMenuItemDto,
            UpdateMenuItemDto>
    {
    }
}