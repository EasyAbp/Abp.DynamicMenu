using Shouldly;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using Volo.Abp.Data;
using Volo.Abp.ObjectMapping;
using Xunit;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public class MenuItemAppServiceTests : DynamicMenuApplicationTestBase
    {
        private readonly IObjectMapper _objectMapper;

        public MenuItemAppServiceTests()
        {
            _objectMapper = GetRequiredService<IObjectMapper>();
        }

        [Fact]
        public void Should_Map_MenuItem_To_MenuItemDto()
        {
            // Arrange
            var menuItem = new MenuItem(
                parentName: "Parent",
                inAdministration: true,
                name: "MyMenu",
                displayName: "My Menu",
                url: "/my-menu",
                urlMvc: "/mvc/my-menu",
                urlBlazor: "/blazor/my-menu",
                urlAngular: "/angular/my-menu",
                permission: "MyPermission",
                order: 42,
                icon: "fa fa-home",
                target: "_blank",
                isDisabled: true,
                lResourceTypeName: "MyResource",
                lResourceTypeAssemblyName: "MyAssembly",
                menuItems: null);

            menuItem.SetProperty("CustomKey", "CustomValue");

            // Act
            var dto = _objectMapper.Map<MenuItem, MenuItemDto>(menuItem);

            // Assert
            dto.ShouldNotBeNull();
            dto.ParentName.ShouldBe("Parent");
            dto.InAdministration.ShouldBeTrue();
            dto.Name.ShouldBe("MyMenu");
            dto.DisplayName.ShouldBe("My Menu");
            dto.Url.ShouldBe("/my-menu");
            dto.UrlMvc.ShouldBe("/mvc/my-menu");
            dto.UrlBlazor.ShouldBe("/blazor/my-menu");
            dto.UrlAngular.ShouldBe("/angular/my-menu");
            dto.Permission.ShouldBe("MyPermission");
            dto.Order.ShouldBe(42);
            dto.Icon.ShouldBe("fa fa-home");
            dto.Target.ShouldBe("_blank");
            dto.IsDisabled.ShouldBeTrue();
            dto.LResourceTypeName.ShouldBe("MyResource");
            dto.LResourceTypeAssemblyName.ShouldBe("MyAssembly");
            dto.GetProperty<string>("CustomKey").ShouldBe("CustomValue");
        }
    }
}
