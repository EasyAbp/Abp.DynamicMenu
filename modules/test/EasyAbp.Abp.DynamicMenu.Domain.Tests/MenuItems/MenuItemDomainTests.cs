using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public class MenuItemDomainTests : DynamicMenuDomainTestBase
    {
        public MenuItemDomainTests()
        {
        }

        [Fact]
        public async Task Should_Create_A_Menu_Item()
        {
            // Arrange

            var repository = ServiceProvider.GetRequiredService<IMenuItemRepository>();

            var handler = ServiceProvider.GetRequiredService<CreateMenuItemEventHandler>();

            var eto = new TryCreateMenuItemEto(null, false, "GoogleLink", "Google", "https://google.com", null, null,
                null, null, null, null, null, false, false, null, null);

            // Act

            await handler.HandleEventAsync(eto);

            var menuItem = await repository.FindAsync(x => x.Id == eto.Id);

            // Assert

            menuItem.ShouldNotBeNull();
            menuItem.ParentId.ShouldBeNull();
            menuItem.InAdministration.ShouldBeFalse();
            menuItem.Id.ShouldBe("GoogleLink");
            menuItem.DisplayName.ShouldBe("Google");
            menuItem.Url.ShouldBe("https://google.com");
        }

        [Fact]
        public async Task Should_Create_An_Administration_Menu_Item()
        {
            // Arrange

            var repository = ServiceProvider.GetRequiredService<IMenuItemRepository>();

            var handler = ServiceProvider.GetRequiredService<CreateMenuItemEventHandler>();

            var eto = new TryCreateMenuItemEto(null, true, "GoogleLink", "Google", "https://google.com", null, null,
                null, null, null, null, null, false, false, null, null);

            // Act

            await handler.HandleEventAsync(eto);

            var menuItem = await repository.FindAsync(x => x.Id == eto.Id);

            // Assert

            menuItem.ShouldNotBeNull();
            menuItem.ParentId.ShouldBeNull();
            menuItem.InAdministration.ShouldBeTrue();
            menuItem.Id.ShouldBe("GoogleLink");
            menuItem.DisplayName.ShouldBe("Google");
            menuItem.Url.ShouldBe("https://google.com");
        }

        [Fact]
        public async Task Should_Create_Menu_Items()
        {
            // Arrange

            var repository = ServiceProvider.GetRequiredService<IMenuItemRepository>();

            var handler = ServiceProvider.GetRequiredService<CreateMenuItemEventHandler>();

            var itemEto1 = new TryCreateMenuItemEto(null, false, "SearchEngines", "Search engines", null, null, null,
                null, null, null, null, null, false, false, null, null);

            var itemEto2 = new TryCreateMenuItemEto(itemEto1.Id, false, "GoogleLink", "Google", "https://google.com",
                null, null, null, null, null, null, null, false, false, null, null);

            var eto = new TryCreateMenuItemsEto(new List<TryCreateMenuItemEto> { itemEto1, itemEto2 });

            // Act

            await handler.HandleEventAsync(eto);

            var menuItem1 = await repository.FindAsync(x => x.Id == itemEto1.Id);
            var menuItem2 = await repository.FindAsync(x => x.Id == itemEto2.Id);

            // Assert

            menuItem1.ShouldNotBeNull();
            menuItem1.ParentId.ShouldBeNull();
            menuItem1.Id.ShouldBe("SearchEngines");
            menuItem1.DisplayName.ShouldBe("Search engines");
            menuItem1.Url.ShouldBeNull();

            menuItem2.ShouldNotBeNull();
            menuItem2.ParentId.ShouldBe(menuItem1.Id);
            menuItem2.Id.ShouldBe("GoogleLink");
            menuItem2.DisplayName.ShouldBe("Google");
            menuItem2.Url.ShouldBe("https://google.com");
        }

        [Fact]
        public async Task Should_Skip_Creating_An_Existing_Menu_Item()
        {
            // Arrange

            var repository = ServiceProvider.GetRequiredService<IMenuItemRepository>();

            var handler = ServiceProvider.GetRequiredService<CreateMenuItemEventHandler>();

            var existingMenuItem = new MenuItem(null, false, "GoogleLink", "Google1", "https://google.com", null, null,
                null, null, null, null, null, false, false, null, null, new List<MenuItem>());

            await repository.InsertAsync(existingMenuItem, true);

            var eto = new TryCreateMenuItemEto(null, false, "GoogleLink", "Google2", "https://google.com", null, null,
                null, null, null, null, null, false, false, null, null);

            // Act

            await handler.HandleEventAsync(eto);

            var menuItem = await repository.FindAsync(x => x.Id == "GoogleLink");

            // Assert

            menuItem.ShouldNotBeNull();
            menuItem.DisplayName.ShouldNotBe("Google2");
            menuItem.DisplayName.ShouldBe("Google1");
        }

        [Fact]
        public async Task Should_Delete_An_Existing_Menu_Item()
        {
            // Arrange

            var repository = ServiceProvider.GetRequiredService<IMenuItemRepository>();

            var handler = ServiceProvider.GetRequiredService<DeleteMenuItemEventHandler>();

            var existingMenuItem1 = new MenuItem(null, false, "GoogleLink1", "Google1", "https://google.com", null,
                null, null, null, null, null, null, false, false, null, null, new List<MenuItem>());

            var existingMenuItem2 = new MenuItem(null, false, "GoogleLink2", "Google2", "https://google.com", null,
                null, null, null, null, null, null, false, false, null, null, new List<MenuItem>());

            await repository.InsertAsync(existingMenuItem1, true);
            await repository.InsertAsync(existingMenuItem2, true);

            var eto1 = new TryDeleteMenuItemEto("GoogleLink1");
            var eto2 = new TryDeleteMenuItemEto("GoogleLink3");

            // Act

            await handler.HandleEventAsync(eto1);
            await handler.HandleEventAsync(eto2);

            var menuItem1 = await repository.FindAsync(x => x.Id == "GoogleLink1");
            var menuItem2 = await repository.FindAsync(x => x.Id == "GoogleLink2");

            // Assert

            menuItem1.ShouldBeNull();

            menuItem2.ShouldNotBeNull();
            menuItem2.DisplayName.ShouldBe("Google2");
        }
    }
}