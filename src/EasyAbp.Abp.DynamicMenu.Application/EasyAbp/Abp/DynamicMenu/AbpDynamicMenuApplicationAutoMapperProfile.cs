using EasyAbp.Abp.DynamicMenu.MenuItems;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using AutoMapper;

namespace EasyAbp.Abp.DynamicMenu
{
    public class AbpDynamicMenuApplicationAutoMapperProfile : Profile
    {
        public AbpDynamicMenuApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            
            CreateMap<MenuItem, MenuItemDto>().MapExtraProperties();
            CreateMap<CreateMenuItemDto, MenuItem>(MemberList.Source).MapExtraProperties();
            CreateMap<UpdateMenuItemDto, MenuItem>(MemberList.Source).MapExtraProperties();
        }
    }
}
