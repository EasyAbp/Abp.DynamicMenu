namespace EasyAbp.Abp.DynamicMenu
{
    public static class DynamicMenuDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpAbpDynamicMenu";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpAbpDynamicMenu";
    }
}
