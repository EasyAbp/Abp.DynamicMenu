using EasyAbp.Abp.DynamicMenu.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.Abp.DynamicMenu.Permissions
{
    public class DynamicMenuPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DynamicMenuPermissions.GroupName, L("Permission:DynamicMenu"));

            var menuItemPermission = myGroup.AddPermission(DynamicMenuPermissions.MenuItem.Default, L("Permission:MenuItem"));
            menuItemPermission.AddChild(DynamicMenuPermissions.MenuItem.Create, L("Permission:Create"));
            menuItemPermission.AddChild(DynamicMenuPermissions.MenuItem.Update, L("Permission:Update"));
            menuItemPermission.AddChild(DynamicMenuPermissions.MenuItem.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DynamicMenuResource>(name);
        }
    }
}
