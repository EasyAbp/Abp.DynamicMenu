using Volo.Abp;

namespace EasyAbp.Abp.DynamicMenu.MenuItems
{
    public sealed class ExceededMenuLevelLimitException : BusinessException
    {
        public ExceededMenuLevelLimitException(int maxLevel)
            : base("EasyAbp.Abp.DynamicMenu:ExceededMenuLevelLimit")
        {
            Data["MaxLevel"] = maxLevel;
        }
    }
}