using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Features;
using Volo.Abp.SettingManagement;

namespace EasyAbp.Abp.DynamicMenu.Demo.SettingManagement;

//[Authorize(SettingManagementPermissions.Emailing)]
public class DemoSettingsAppService(ISettingManager settingManager) : SettingManagementAppServiceBase, IDemoSettingsAppService
{
    public virtual async Task<DemoSettingsDto> GetAsync()
    {
        await CheckFeatureAsync();

        var settingsDto = new DemoSettingsDto
        {
            RememberGridFilterState = Convert.ToBoolean(await SettingProvider.GetOrNullAsync(DemoSettingNames.RememberGridFilterState)),
        };

        return settingsDto;
    }

    public virtual async Task UpdateAsync(UpdateDemoSettingsDto input)
    {
        await CheckFeatureAsync();

        await settingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, DemoSettingNames.RememberGridFilterState, input.RememberGridFilterState.ToString().ToLowerInvariant());
    }

    protected virtual async Task CheckFeatureAsync()
    {
        await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.Enable);
        if (CurrentTenant.IsAvailable)
        {
            await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.AllowChangingEmailSettings);
        }
    }
}
