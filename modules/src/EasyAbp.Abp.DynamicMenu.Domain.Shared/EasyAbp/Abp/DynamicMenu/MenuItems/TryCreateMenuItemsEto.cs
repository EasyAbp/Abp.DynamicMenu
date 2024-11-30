using System;
using System.Collections.Generic;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    [Serializable]
    public class TryCreateMenuItemsEto : ExtensibleObject
    {
        public List<TryCreateMenuItemEto> Items { get; set; }

        public TryCreateMenuItemsEto(List<TryCreateMenuItemEto> items)
        {
            Items = items;
        }
    }
}