using Volo.Abp;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public sealed class NonexistentParentMenuItemException : BusinessException
    {
        public NonexistentParentMenuItemException(string parentName)
            : base("EasyAbp.Abp.DynamicMenu:NonexistentParentMenuItem")
        {
            Data["ParentName"] = parentName;
        }
    }
}