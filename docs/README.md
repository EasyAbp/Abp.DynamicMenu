# Abp.DynamicMenu

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FAbpVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FEasyAbp%2FAbp.DynamicMenu%2Fmaster%2FDirectory.Build.props)](https://abp.io)
[![NuGet](https://img.shields.io/nuget/v/EasyAbp.Abp.DynamicMenu.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Abp.DynamicMenu.Domain.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.Abp.DynamicMenu.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.Abp.DynamicMenu.Domain.Shared)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/Abp.DynamicMenu?style=social)](https://www.github.com/EasyAbp/Abp.DynamicMenu)

An abp module that dynamically creates menu items for ABP UI projects in runtime.

## Online Demo

We have launched an online demo for this module: [https://dynamicmenu.samples.easyabp.io](https://dynamicmenu.samples.easyabp.io)

![demo.gif](/docs/images/demo.gif)

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-nuget-packages))

    * EasyAbp.Abp.DynamicMenu.Application
    * EasyAbp.Abp.DynamicMenu.Application.Contracts
    * EasyAbp.Abp.DynamicMenu.Domain
    * EasyAbp.Abp.DynamicMenu.Domain.Shared
    * EasyAbp.Abp.DynamicMenu.EntityFrameworkCore
    * EasyAbp.Abp.DynamicMenu.HttpApi
    * EasyAbp.Abp.DynamicMenu.HttpApi.Client
    * EasyAbp.Abp.DynamicMenu.Web

1. Add `DependsOn(typeof(AbpDynamicMenuXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-module-dependencies))

1. Add `builder.ConfigureAbpDynamicMenu();` to the `OnModelCreating()` method in **MyProjectMigrationsDbContext.cs**.

1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC&DB=EF#add-database-migration).

## Usage

1. Create a dynamic menu item on the management page.

2. Refresh the page and you can see the menu item you just created.

## Road map

- [ ] More customizable options for menu items.
