using Volo.Abp.Reflection;

namespace EasyAbp.Abp.DynamicMenu.Permissions
{
    public class DynamicMenuPermissions
    {
        public const string GroupName = "EasyAbp.Abp.DynamicMenu";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(DynamicMenuPermissions));
        }

        public class MenuItem
        {
            public const string Default = GroupName + ".MenuItem";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
