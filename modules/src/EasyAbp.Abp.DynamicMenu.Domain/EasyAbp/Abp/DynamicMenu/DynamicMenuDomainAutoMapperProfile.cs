using AutoMapper;
using EasyAbp.Abp.DynamicMenu.MenuItems;

namespace EasyAbp.Abp.DynamicMenu
{
    public class DynamicMenuDomainAutoMapperProfile : Profile
    {
        public DynamicMenuDomainAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            
            CreateMap<TryCreateMenuItemEto, MenuItem>(MemberList.Source).MapExtraProperties();
        }
    }
}
