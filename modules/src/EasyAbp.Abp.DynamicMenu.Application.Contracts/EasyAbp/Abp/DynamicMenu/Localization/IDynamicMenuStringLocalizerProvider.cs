using System;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using Microsoft.Extensions.Localization;

namespace EasyAbp.Abp.DynamicMenu.Localization
{
    public interface IDynamicMenuStringLocalizerProvider
    {
        Task<IStringLocalizer> GetAsync(MenuItemDto menuItem);
        
        Task<string> GetResourceNameAsync(MenuItemDto menuItem);

        Task<Type> GetResourceTypeOrNullAsync(MenuItemDto menuItem);
    }
}