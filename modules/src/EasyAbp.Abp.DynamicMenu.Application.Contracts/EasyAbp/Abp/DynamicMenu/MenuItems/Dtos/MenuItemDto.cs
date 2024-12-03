using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Validation;

namespace EasyAbp.Abp.DynamicMenu.MenuItems.Dtos
{

    [Serializable]
    public class MenuItemDto : ExtensibleEntityDto<string>, IHasConcurrencyStamp
    {
        public string ParentId { get; set; }

        public bool InAdministration { get; set; }

        public string DisplayName { get; set; }

        public string Url { get; set; }

        public string UrlMvc { get; set; }

        public string UrlBlazor { get; set; }

        public string UrlAngular { get; set; }

        public string Permission { get; set; }

        public int? Order { get; set; }

        public string Icon { get; set; }

        public string Target { get; set; }

        public bool IsPublic { get; set; }

        public bool IsDisabled { get; set; }

        public string LResourceTypeName { get; set; }

        public string LResourceTypeAssemblyName { get; set; }

        public List<MenuItemDto> MenuItems { get; set; }

        public virtual Guid? CreatorId { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}