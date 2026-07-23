using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using EasyAbp.Abp.DynamicMenu.Web.Pages.Abp.DynamicMenu.MenuItems.MenuItem.ViewModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.Abp.DynamicMenu.Web
{
    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class MenuItemDtoToEditMenuItemViewModelMapper : MapperBase<MenuItemDto, EditMenuItemViewModel>
    {
        public override partial EditMenuItemViewModel Map(MenuItemDto source);

        public override partial void Map(MenuItemDto source, EditMenuItemViewModel destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class CreateMenuItemViewModelToCreateMenuItemDtoMapper : MapperBase<CreateMenuItemViewModel, CreateMenuItemDto>
    {
        [MapperIgnoreTarget(nameof(CreateMenuItemDto.ExtraProperties))]
        public override partial CreateMenuItemDto Map(CreateMenuItemViewModel source);

        [MapperIgnoreTarget(nameof(CreateMenuItemDto.ExtraProperties))]
        public override partial void Map(CreateMenuItemViewModel source, CreateMenuItemDto destination);
    }

    [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
    public partial class EditMenuItemViewModelToUpdateMenuItemDtoMapper : MapperBase<EditMenuItemViewModel, UpdateMenuItemDto>
    {
        [MapperIgnoreTarget(nameof(UpdateMenuItemDto.ExtraProperties))]
        public override partial UpdateMenuItemDto Map(EditMenuItemViewModel source);

        [MapperIgnoreTarget(nameof(UpdateMenuItemDto.ExtraProperties))]
        public override partial void Map(EditMenuItemViewModel source, UpdateMenuItemDto destination);
    }
}
