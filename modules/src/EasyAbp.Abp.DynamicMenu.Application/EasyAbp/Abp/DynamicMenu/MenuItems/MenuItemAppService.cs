using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.Permissions;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public class MenuItemAppService : AbstractKeyCrudAppService<MenuItem, MenuItemDto, string, GetMenuItemListInput
            , CreateMenuItemDto, UpdateMenuItemDto>,
        IMenuItemAppService
    {
        protected override string GetPolicyName { get; set; } = null;
        protected override string GetListPolicyName { get; set; } = null;
        protected override string CreatePolicyName { get; set; } = DynamicMenuPermissions.MenuItem.Create;
        protected override string UpdatePolicyName { get; set; } = DynamicMenuPermissions.MenuItem.Update;
        protected override string DeletePolicyName { get; set; } = DynamicMenuPermissions.MenuItem.Delete;

        private readonly IMenuItemRepository _repository;

        public MenuItemAppService(IMenuItemRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<MenuItem>> CreateFilteredQueryAsync(GetMenuItemListInput input)
        {
            return (await _repository.WithDetailsAsync()).Where(x => x.ParentId == input.ParentId);
        }

        protected override Task DeleteByIdAsync(string id)
        {
            // TODO: AbpHelper generated
            return _repository.DeleteAsync(e =>
                e.Id == id
            );
        }

        protected override async Task<MenuItem> GetEntityByIdAsync(string id)
        {
            // TODO: AbpHelper generated
            return await AsyncExecuter.FirstOrDefaultAsync(
                (await _repository.WithDetailsAsync()).Where(e =>
                    e.Id == id
                )
            );
        }

        protected override IQueryable<MenuItem> ApplyDefaultSorting(IQueryable<MenuItem> query)
        {
            // TODO: AbpHelper generated
            return query.OrderBy(e => e.Id);
        }

        public override async Task<MenuItemDto> CreateAsync(CreateMenuItemDto input)
        {
            await CheckCreatePolicyAsync();

            await CheckParentIdAsync(input.ParentId);

            var entity = await MapToEntityAsync(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<MenuItemDto> UpdateAsync(string id, UpdateMenuItemDto input)
        {
            await CheckUpdatePolicyAsync();

            await CheckParentIdAsync(input.ParentId);

            var entity = await GetEntityByIdAsync(id);

            entity.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

            await MapToEntityAsync(input, entity);


            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task DeleteAsync(string id)
        {
            await CheckDeletePolicyAsync();

            var menuItem = await GetEntityByIdAsync(id);

            await RecursiveDeleteAsync(menuItem);

            await CurrentUnitOfWork.SaveChangesAsync();
        }

        protected virtual async Task RecursiveDeleteAsync(MenuItem menuItem)
        {
            if (!menuItem.MenuItems.IsNullOrEmpty())
            {
                foreach (var subItem in menuItem.MenuItems)
                {
                    await RecursiveDeleteAsync(subItem);
                }
            }

            await _repository.DeleteAsync(menuItem);
        }

        protected async Task CheckParentIdAsync([CanBeNull] string parentId)
        {
            if (parentId == null)
            {
                return;
            }

            var parent = await _repository.FindAsync(x => x.Id == parentId);

            if (parent == null)
            {
                throw new NonexistentParentMenuItemException(parentId);
            }

            // Maximum menu item level: 3
            if (!parent.ParentId.IsNullOrEmpty())
            {
                var grandparent = await _repository.GetAsync(x => x.Id == parent.ParentId);

                if (grandparent.ParentId != null)
                {
                    throw new ExceededMenuLevelLimitException(3);
                }
            }
        }
    }
}