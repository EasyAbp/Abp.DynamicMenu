using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace EasyAbp.Abp.ObjectExtending;

public static class DynamicMenuModuleExtensionConfigurationDictionaryExtensions
{
    public static ModuleExtensionConfigurationDictionary ConfigureDynamicMenu(
        this ModuleExtensionConfigurationDictionary modules,
        Action<DynamicMenuModuleExtensionConfiguration> configureAction)
    {
        return modules.ConfigureModule(
            DynamicMenuModuleExtensionConsts.ModuleName,
            configureAction
        );
    }
}
