---
title: DGMJR-IO SDK
authors:
  - dgmjr
type: readme
slug: dgmjr-io-sdk
project: shared
description: An SDK that sets a whole boatload of default values and does a shit ton of stuff automagically.
version: 0.0.1
lastmod: 2023-07-14T07:49:58.705Z
date: 2023-07-14T07:49:16.139Z
license: MIT
keywords:
  - dotnet
  - sdk
  - dgmjrsdk
  - defaults
  - default-values
---

# DGMJR-IO SDK

An SDK that sets a whole boatload of default values and does a shit ton of stuff automagically.

# Getting Started

Put the following code in your `Directory.Build.props` file:

```xml
<Include Sdk="DgmjrSdk" File="Sdk.props" />
```

And put the following code in your `Directory.Build.targets` file:

```xml
<Include Sdk="DgmjrSdk" File="Sdk.targets" />
```

And make sure to add the following to your `global.json` file:

```json
"msbuild-sdks":{
  "DgmjrSdk": "[the-current-version]"
}
```

Then compile and run your project and it will have all the DGMJR-IO SDK defaults.  These include the following:

## Item Definitions

* `Author` - with `Initials` and `Email` metadata, which populate the `Authors` property of the MSBuild (and NuGet) project
* `Owner` - with `Initials` and `Email` metadata, which populate the `Owners` and `Copyright` properties of the MSBuild (and NuGet) project
* `PackageTag` - which concatenates all instances of it and populates the `PackageTags` property of the MSBuild (and NuGet) project
* `SourceCodeReference`, which behaves just like a `PackageReference` except it just pulls the `ContentFiles` and `Build` assets from the package
* `SourceGenerator`, which behaves just like a `PackageReference` except it just pulls the `Analyzers` and `Build` assets from the package
* `NoWarn`, which adds all instances to the `NoWarn` property

## Targets

* `EnsurePackageReadme`, which ensures the package contains a `README.md` file at the root; if not, it generates one from the `Title` and `Description` properties and embeds it into the NuGet package
* `EnsurePackageIcon`, which ensures the package contains an icon file; if theres no file named `Icon.(png/jpg/jpeg)` at the root, it will use a [default icon](https://github.com/dgmjr-io/DgmjrSdk/blob/main/src/Assets/Icon.png)
* `RemoveDuplicateUsings`, which removes any duplicate `Using` items from the project
* `PackageProjectName.targets` - a file that packages any file in the root directory named `[MSBuildProjectName].targets` into the `build` folder of the NuGet package
* `PackageProjectName.props` - a file that packages any file in the root directory named `[MSBuildProjectName].props` into the `build` folder of the NuGet package

## Properties

* `PackageVersionOverride`, which allows you to override the package version calculated by `MinVer`
* A default `UserSecrets` property
* Default `AssetTargetFallback`s for all .NET versions from .NETStandard 2.0 through .NET 8.0
* Default values for generating XML documentation as well as pulling the XML docs from referenced packages
* All `Include[Whatever]OutputGroup` properties set to `true`
* [`JustInTimeVersioning`](https://github.com/dgmjr-io/JustInTimeVersioning) enabled
* [`NuGetPush`](https://github.com/dgmjr-io/NuGetPush) enabled
* 

# Miscellaneous

* Assembly signing - ensures the assembly is signed by a key called [`dgmjr.snk`](https://github.com/dgmjr-io/DgmjrSdk/blob/main/src/Assets/dgmjr.snk) located in the [`Assets`](https://github.com/dgmjr-io/DgmjrSdk/blob/main/src/Assets) folder.  There's also [`dgmjr.pub`](https://github.com/dgmjr-io/DgmjrSdk/blob/main/src/Assets/dgmjr.pub) (the binary version of the public key) and [`dgmjr.pub.asc`](https://github.com/dgmjr-io/DgmjrSdk/blob/main/src/Assets/dgmjr.pub.asc), which contains the plain text public key and token.
* TestingLocal - Overrides the `AssemblyVersion` attribute to always be `0.0.1-Local` when the `Configuration` is set to `Local`
* [`Icon.png`](https://github.com/dgmjr-io/DgmjrSdk/blob/main/src/Assets/Icon.png), a default icon file, which will be applied to any package that doesn't have one.
* [`NuGetizer`](https://github.com/devlooped/nugetizer) enabled by default
