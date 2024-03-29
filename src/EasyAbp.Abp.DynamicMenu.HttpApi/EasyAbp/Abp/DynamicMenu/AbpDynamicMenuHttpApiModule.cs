﻿using Localization.Resources.AbpUi;
using EasyAbp.Abp.DynamicMenu.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EasyAbp.Abp.DynamicMenu
{
    [DependsOn(
        typeof(AbpDynamicMenuApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AbpDynamicMenuHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AbpDynamicMenuHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<DynamicMenuResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
