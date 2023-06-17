---

authors:
- dgmjr
title: The DGMJR SDK
modified: 2023-01-09-06:51:33
created: 2023-01-09-06:51:31
license: MIT
description: The DGMJR SDK is a collection of `.props` and `.targets` files that are used to build and package the DGMJR projects.
slug: readme-md
keywords:
- DGMJR-IO
- readme
- sdk
- msbuild
categories:
- documentation
- msbuild
- readme
- sdk
-----

# The DGMJR SDK

The DGMJR SDK is a collection of `.props` and `.targets` files that are used to build and package the DGMJR-IO projects.

## Getting Started

Create a `Directory.Build.props` file in the root of your project and add the following:

```xml
<Project>
    <Import Project="Sdk.props" Sdk="DgmjrSdk" />
</Project>
```

Then create a `Directory.Build.targets` file in the same directory and add the following:

```xml
<Project>
    <Import Project="Sdk.targets" Sdk="DgmjrSdk" />
</Project>
```

Then create (or alter) your `global.json` file to include the following:

```json
{
    "msbuild-sdks": {
        "DgmjrSdk": "1.5.0[or-the-current-version]"
    }
}
```

Then build your project.  It will have all of the Dgmjr SDK defaults.
