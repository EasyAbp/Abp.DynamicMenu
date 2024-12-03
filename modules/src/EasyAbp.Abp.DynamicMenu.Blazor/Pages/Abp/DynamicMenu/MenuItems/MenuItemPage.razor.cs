using System.Threading.Tasks;
using Blazorise;
using System;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Volo.Abp.AspNetCore.Components.Web.Theming.PageToolbars;
using EasyAbp.Abp.DynamicMenu.Permissions;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using EasyAbp.Abp.DynamicMenu.Localization;
using EasyAbp.Abp.DynamicMenu.Blazor.Components;
using EasyAbp.Abp.ObjectExtending;

namespace EasyAbp.Abp.DynamicMenu.Blazor.Pages.Abp.DynamicMenu.MenuItems;

public partial class MenuItemPage
{
    protected PageToolbar Toolbar { get; } = new();

    protected List<TableColumn> MenuItemTableColumns => TableColumns.Get<MenuItemDto>();

    public MenuItemPage()
    {
        ObjectMapperContext = typeof(AbpDynamicMenuBlazorModule);
        LocalizationResource = typeof(DynamicMenuResource);

        CreatePolicyName = DynamicMenuPermissions.MenuItem.Create;
        UpdatePolicyName = DynamicMenuPermissions.MenuItem.Update;
        DeletePolicyName = DynamicMenuPermissions.MenuItem.Delete;
    }

    protected override ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:DynamicMenu"].Value));
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["MenuItems"].Value));
        return base.SetBreadcrumbItemsAsync();
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        EntityActions
            .Get<MenuItemDto>()
            .AddRange(new EntityAction[]
            {
                    new EntityAction
                    {
                        Text = L["Edit"],
                        Visible = (data) => HasUpdatePermission,
                        Clicked = async (data) => { await OpenEditModalAsync(data.As<MenuItemDto>()); }
                    },
                    new EntityAction
                    {
                        Text = L["Delete"],
                        Visible = (data) => HasDeletePermission,
                        Clicked = async (data) => await DeleteEntityAsync(data.As<MenuItemDto>()),
                        ConfirmationMessage = (data) => GetDeleteConfirmationMessage(data.As<MenuItemDto>())
                    }
            });

        return base.SetEntityActionsAsync();
    }

    protected override async ValueTask SetTableColumnsAsync()
    {
        MenuItemTableColumns
            .AddRange(new TableColumn[]
            {
                    new TableColumn
                    {
                        Title = L["Actions"],
                        Actions = EntityActions.Get<MenuItemDto>(),
                    },
                    new TableColumn
                    {
                        Title = L["MenuName"],
                        Sortable = true,
                        Data = nameof(MenuItemDto.Id),
                        Component = typeof(MenuNameComponent)
                    },
                    new TableColumn
                    {
                        Title = L["DisplayName"],
                        Sortable = true,
                        Data = nameof(MenuItemDto.DisplayName),
                    },
            });

        MenuItemTableColumns.AddRange(GetExtensionTableColumns(DynamicMenuModuleExtensionConsts.ModuleName,
            DynamicMenuModuleExtensionConsts.EntityNames.MenuItem));

        await base.SetTableColumnsAsync();
    }

    protected override async Task SetPermissionsAsync()
    {
        await base.SetPermissionsAsync();
    }

    protected override string GetDeleteConfirmationMessage(MenuItemDto entity)
    {
        return string.Format(L["MenuItemDeletionConfirmationMessage"], entity.Id);
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(L["NewMenuItem"],
            OpenCreateModalAsync,
            IconName.Add,
            requiredPolicyName: CreatePolicyName);

        return base.SetToolbarItemsAsync();
    }
}