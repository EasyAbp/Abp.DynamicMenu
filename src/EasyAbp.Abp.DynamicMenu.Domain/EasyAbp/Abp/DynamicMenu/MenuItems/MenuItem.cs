using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public class MenuItem : AggregateRoot, IMenuItem
    {
        public virtual string ParentName { get; protected set; }

        [Key]
        public virtual string Name { get; protected set; }
        
        public virtual string DisplayName { get; protected set; }
        
        public virtual string Url { get; protected set; }
        
        public virtual string UrlMvc { get; protected set; }
        
        public virtual string UrlBlazor { get; protected set; }
        
        public virtual string UrlAngular { get; protected set; }
        
        public virtual string Permission { get; protected set; }
        
        public virtual string LResourceTypeName { get; protected set; }
        
        public virtual string LResourceTypeAssemblyName { get; protected set; }
        
        [ForeignKey(nameof(ParentName))]
        public virtual List<MenuItem> MenuItems { get; protected set; }

        public override object[] GetKeys()
        {
            return new object[] {Name};
        }

        protected MenuItem()
        {
            MenuItems = new List<MenuItem>();
        }

        public MenuItem(
            string parentName,
            string name,
            string displayName,
            string url,
            string urlMvc,
            string urlBlazor,
            string urlAngular,
            string permission,
            string lResourceTypeName,
            string lResourceTypeAssemblyName,
            List<MenuItem> menuItems
        )
        {
            ParentName = parentName;
            Name = name;
            DisplayName = displayName;
            Url = url;
            UrlMvc = urlMvc;
            UrlBlazor = urlBlazor;
            UrlAngular = urlAngular;
            Permission = permission;
            LResourceTypeName = lResourceTypeName;
            LResourceTypeAssemblyName = lResourceTypeAssemblyName;
            MenuItems = menuItems ?? new List<MenuItem>();
        }
    }
}
