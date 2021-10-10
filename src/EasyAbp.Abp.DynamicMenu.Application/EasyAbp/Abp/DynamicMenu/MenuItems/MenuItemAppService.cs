using System.Linq;
using System.Threading.Tasks;
using EasyAbp.Abp.DynamicMenu.Permissions;
using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public class MenuItemAppService : AbstractKeyCrudAppService<MenuItem, MenuItemDto, MenuItemKey, GetMenuItemListInput, CreateMenuItemDto, UpdateMenuItemDto>,
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
            return (await _repository.WithDetailsAsync()).Where(x => x.ParentName == input.ParentName);
        }

        protected override Task DeleteByIdAsync(MenuItemKey id)
        {
            // TODO: AbpHelper generated
            return _repository.DeleteAsync(e =>
                e.Name == id.Name
            );
        }

        protected override async Task<MenuItem> GetEntityByIdAsync(MenuItemKey id)
        {
            // TODO: AbpHelper generated
            return await AsyncExecuter.FirstOrDefaultAsync(
                _repository.Where(e =>
                    e.Name == id.Name
                )
            ); 
        }

        protected override IQueryable<MenuItem> ApplyDefaultSorting(IQueryable<MenuItem> query)
        {
            // TODO: AbpHelper generated
            return query.OrderBy(e => e.Name);
        }

        public override async Task<MenuItemDto> CreateAsync(CreateMenuItemDto input)
        {
            await CheckCreatePolicyAsync();

            await CheckParentNameAsync(input.ParentName);

            var entity = await MapToEntityAsync(input);

            TryToSetTenantId(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<MenuItemDto> UpdateAsync(MenuItemKey id, UpdateMenuItemDto input)
        {
            await CheckUpdatePolicyAsync();

            await CheckParentNameAsync(input.ParentName);

            var entity = await GetEntityByIdAsync(id);

            await MapToEntityAsync(input, entity);
            
            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        protected async Task CheckParentNameAsync([CanBeNull] string parentName)
        {
            if (parentName == null)
            {
                return;
            }

            if (await _repository.FindAsync(x => x.Name == parentName) == null)
            {
                throw new NonexistentParentMenuItemException(parentName);
            }
        }
    }
}
