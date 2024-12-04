using EasyAbp.Abp.DynamicMenu.MenuItems.Dtos;
using Volo.Abp.Application.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using System;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    [RemoteService(Name = AbpDynamicMenuRemoteServiceConsts.RemoteServiceName)]
    [Route("/api/dynamic-menu/menu-item")]
    public class MenuItemController : DynamicMenuController, IMenuItemAppService
    {
        private readonly IMenuItemAppService _service;

        public MenuItemController(IMenuItemAppService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public virtual Task<MenuItemDto> CreateAsync(CreateMenuItemDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MenuItemDto> UpdateAsync(string id, UpdateMenuItemDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(string id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MenuItemDto> GetAsync(string id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        [Route("")]
        public virtual Task<PagedResultDto<MenuItemDto>> GetListAsync(GetMenuItemListInput input)
        {
            return _service.GetListAsync(input);
        }
    }
}