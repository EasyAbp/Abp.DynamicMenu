using System;
using JetBrains.Annotations;
using Volo.Abp.ObjectExtending;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    [Serializable]
    public class TryDeleteMenuItemEto : ExtensibleObject
    {
        [NotNull]
        public string Id { get; set; }

        public TryDeleteMenuItemEto([NotNull] string id)
        {
            Id = id;
        }
    }
}