using EasyAbp.Abp.DynamicMenu.MenuItems;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Abp.DynamicMenu
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    [MapExtraProperties]
    public partial class MenuItemToMenuItemDtoMapper : MapperBase<MenuItem, MenuItemDto>
    {
        public override partial MenuItemDto Map(MenuItem source);

        public override partial void Map(MenuItem source, MenuItemDto destination);
    }
}
