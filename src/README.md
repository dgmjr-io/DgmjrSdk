---
author: Justin Chase
author_email: justin@justinwritescode.com
title: README.md
modified: 2023-01-09-06:51:33
created: 2023-01-09-06:51:31
license: MIT
categories:
  - documentation
  - msbuild
  - readme
  - sdk
description: A README file for the JustinWritesCode SDK
slug: readme-md
keywords:
  - justinwritescode
  - readme
  - sdk
  - msbuild
---

# The JustinWritesCode SDK

The JustinWritesCode SDK is a collection of `.props` and `.targets` files that are used to build and package the Backroom projects.

## Getting Started

Create a `Directory.Build.props` file in the root of your project and add the following:

```xml
<Project>
    <Import Project="Sdk.props" Sdk="JustinWritesCodeSdk" />
</Project>
```

Then create a `Directory.Build.targets` file in the same directory and add the following:

```xml
<Project>
    <Import Project="Sdk.targets" Sdk="JustinWritesCodeSdk" />
</Project>
```

Then create (or alter) your `global.json` file to include the following:

```json
{
    "msbuild-sdks": {
        "JustinWritesCodeSdk": "TheCurrentVersionOfTheJustinWritesCodeSdk"
    }
}
```

Then build your project.  It will have all of the JustinWritesCode SDK defaults.
