using EasyAbp.Abp.DynamicMenu.Demo.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Settings;

namespace EasyAbp.Abp.DynamicMenu.Demo.Settings;

public class AlphaSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AlphaSettings.MySetting1));

        //Gridin son filtre ayarlarını anımsa
        context.Add(new SettingDefinition(AlphaSettings.RememberGridFilterState, "false", L("DisplayName:EasyAbp.Abp.DynamicMenu.RememberGridFilterState"), L("Description:EasyAbp.Abp.DynamicMenu.RememberGridFilterState")));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DemoResource>(name);
    }
}
