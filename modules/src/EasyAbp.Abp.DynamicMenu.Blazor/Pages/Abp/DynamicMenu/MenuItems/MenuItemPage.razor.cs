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
using System.Linq;

namespace EasyAbp.Abp.DynamicMenu.Blazor.Pages.Abp.DynamicMenu.MenuItems;

public partial class MenuItemPage
{
    protected PageToolbar Toolbar { get; } = new();

    protected List<TableColumn> MenuItemTableColumns => TableColumns.Get<MenuItemViewModel>();

    public MenuItemPage()
    {
        ObjectMapperContext = typeof(AbpDynamicMenuBlazorModule);
        LocalizationResource = typeof(DynamicMenuResource);

        CreatePolicyName = DynamicMenuPermissions.MenuItem.Create;
        UpdatePolicyName = DynamicMenuPermissions.MenuItem.Update;
        DeletePolicyName = DynamicMenuPermissions.MenuItem.Delete;
    }

    public string CurrentParentId { get; set; } = null;

    protected override Task UpdateGetListInputAsync()
    {
        GetListInput.ParentId = CurrentParentId;
        //GetListInput.ParentIdChanged = ParentIdChanged;
        return base.UpdateGetListInputAsync();
    }

    protected override  async Task GetEntitiesAsync()
    {
        try
        {
            await UpdateGetListInputAsync();
            var result = await AppService.GetListAsync(GetListInput);
            Entities = MapToListViewModel(result.Items);
            foreach (var item in Entities) item.ParentIdChanged = ParentIdChanged;
            TotalCount = (int?)result.TotalCount;
        }
        catch (Exception ex)
        {
            await HandleErrorAsync(ex);
        }
    }
    private IReadOnlyList<MenuItemViewModel> MapToListViewModel(IReadOnlyList<MenuItemDto> dtos)
    {
        return ObjectMapper.Map<IReadOnlyList<MenuItemDto>, List<MenuItemViewModel>>(dtos);
    }


    public async Task ParentIdChanged(string parentId)
    {
        CurrentParentId = parentId;
        await GetEntitiesAsync();
        BreadcrumbItems.Clear();
        await SetBreadcrumbItemsAsync();
        await InvokeAsync(StateHasChanged);
    }

    protected override async ValueTask SetBreadcrumbItemsAsync()
    {
        BreadcrumbItems.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(L["Menu:DynamicMenu"].Value));
        MenuItemParents.Clear();
        await FindParents(CurrentParentId);
        MenuItemParents.Reverse();
        BreadcrumbItems.AddRange(MenuItemParents);
        await base.SetBreadcrumbItemsAsync();
    }
    private List<Volo.Abp.BlazoriseUI.BreadcrumbItem> MenuItemParents = new();
    public async Task FindParents(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var item = await AppService.GetAsync(id);
            if (item != null)
            {
                MenuItemParents.Add(new Volo.Abp.BlazoriseUI.BreadcrumbItem(item.DisplayName));
                await FindParents(item.ParentId);
            }
        }
        await Task.CompletedTask;
    }

    protected override ValueTask SetEntityActionsAsync()
    {
        EntityActions
            .Get<MenuItemViewModel>()
            .AddRange(new EntityAction[]
            {
                    new EntityAction
                    {
                        Text = L["Edit"],
                        Visible = (data) => HasUpdatePermission,
                        Clicked = async (data) => { await OpenEditModalAsync(data.As<MenuItemViewModel>()); }
                    },
                    new EntityAction
                    {
                        Text = L["SubMenuItems"],
                        Visible = (data) => true,
                        Clicked = async (data) => await ParentIdChanged(data.As<MenuItemViewModel>().Id),
                    },
                    new EntityAction
                    {
                        Text = L["Delete"],
                        Visible = (data) => HasDeletePermission,
                        Clicked = async (data) => await DeleteEntityAsync(data.As<MenuItemViewModel>()),
                        ConfirmationMessage = (data) => GetDeleteConfirmationMessage(data.As<MenuItemViewModel>())
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
                        Actions = EntityActions.Get<MenuItemViewModel>(),
                    },
                    new TableColumn
                    {
                        Title = L["MenuItemId"],
                        Sortable = true,
                        Data = nameof(MenuItemViewModel.Id),
                        Component = typeof(MenuNameComponent)
                    },
                    new TableColumn
                    {
                        Title = L["MenuItemDisplayName"],
                        Sortable = true,
                        Data = nameof(MenuItemViewModel.DisplayName),
                        Component=typeof(MenuItemPathComponent)
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

    protected override string GetDeleteConfirmationMessage(MenuItemViewModel entity)
    {
        return string.Format(L["MenuItemDeletionConfirmationMessage"], entity.Id);
    }

    public async Task GotoParentId()
    {
        if (!string.IsNullOrEmpty(CurrentParentId))
        {
            var item = await AppService.GetAsync(CurrentParentId);
            await ParentIdChanged(item.ParentId);
        }
        await Task.CompletedTask;
    }

    protected override ValueTask SetToolbarItemsAsync()
    {
        Toolbar.AddButton(L["NewMenuItem"],
            OpenCreateModalAsync,
            IconName.Add,
            requiredPolicyName: CreatePolicyName);

        Toolbar.AddButton("..", GotoParentId,
            "fas fa-folder");

        return base.SetToolbarItemsAsync();
    }
}