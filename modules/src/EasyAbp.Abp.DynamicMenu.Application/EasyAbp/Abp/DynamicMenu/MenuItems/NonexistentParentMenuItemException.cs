using Volo.Abp;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public sealed class NonexistentParentMenuItemException : BusinessException
    {
        public NonexistentParentMenuItemException(string parentId)
            : base("EasyAbp.Abp.DynamicMenu:NonexistentParentMenuItem")
        {
            Data["ParentId"] = parentId;
        }
    }
}