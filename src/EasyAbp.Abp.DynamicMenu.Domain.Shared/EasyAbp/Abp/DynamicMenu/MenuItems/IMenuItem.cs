﻿using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public interface IMenuItem
    {
        [CanBeNull]
        string ParentName { get; }

        [Key]
        [NotNull]
        string Name { get; }
        
        [NotNull]
        string DisplayName { get; }
        
        [CanBeNull]
        string Url { get; }
        
        [CanBeNull]
        string UrlMvc { get; }
        
        [CanBeNull]
        string UrlBlazor { get; }
        
        [CanBeNull]
        string UrlAngular { get; }
        
        [CanBeNull]
        string Permission { get; }
        
        [CanBeNull]
        string LResourceTypeName { get; }
        
        [CanBeNull]
        string LResourceTypeAssemblyName { get; }
    }
}