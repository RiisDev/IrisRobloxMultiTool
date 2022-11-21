# NuGet package - Selenium WebDriver GeckoDriver

[![NuGet Package](https://img.shields.io/nuget/v/Selenium.WebDriver.GeckoDriver.svg)](https://www.nuget.org/packages/Selenium.WebDriver.GeckoDriver/)

## What's this?

This NuGet package install Gecko Driver for Selenium WebDriver into your Unit Test Project.

"geckodriver(.exe)" does not appear in Solution Explorer, but it is copied to the output folder from the package folder when the build process.

NuGet package restoring ready, and no need to commit "geckodriver(.exe)" binary into source code control repository.

## How to install?

For example, at the package manager console on Visual Studio, enter the following command.

    PM> Install-Package Selenium.WebDriver.GeckoDriver -Version 0.32.0

## Cross-platform building and publishing

### By default - it depends on the OS running the build process

By default, the platform type of the web driver file copied to the output folder depends on the OS running the build process.

- When you build the project which references the NuGet package of geckodriver **on 32bit Windows OS**, **win32 version** of geckodriver will be copied to the output folder.
- When you build the project which references the NuGet package of geckodriver **on 64bit Windows OS**, **win64 version** of geckodriver will be copied to the output folder.
- When you build it **on macOS on Intel CPU hardware**, **macOS x64 version** of geckodriver will be copied to the output folder.
- When you build it **on macOS on Apple CPU hardware**, **macOS Arm64 version** of geckodriver will be copied to the output folder.
- When you build it on **any Linux distributions**, **Linux x64 version** of geckodriver will be copied to the output folder.

### Method 1 - Specify "Runtime Identifier"

When you specify the "Runtime Identifier (**RID**)" explicitly, the platform type of the driver file is the same to the RID which you specified. (it doesn't depends on the which OS to use for build process.)

You can specify RID as a MSBuild property in a project file,

```xml
<PropertyGroup>
  <RuntimeIdentifier>win-x64</RuntimeIdentifier>
</PropertyGroup>
```

or, as a command-line `-r` option for dotnet build command.

```shell
> dotnet build -r:osx.10.12-x64
```

- When the RID that **starts with "win"** and **contains "x86"** is specified, **win32 version** of geckodriver will be copied to the output folder.
- When the RID that **starts with "win"** and **contains "x64"** is specified, **win64 version** of geckodriver will be copied to the output folder.
- When the RID that **starts with "osx"** and **ends with "x64"** is specified, **macOS x64 version** of geckodriver will be copied to the output folder.
- When the RID that **starts with "osx"** and **ends with "arm64"** is specified, **macOS Arm64 version** of geckodriver will be copied to the output folder.
- When the RID that **starts with "linux"** is specified, **Linux x64 version** of geckodriver will be copied to the output folder.

If you specify another pattern of RID like "ubuntu.18.04-x64", the platform type of the web driver file which will be copied to the output folder depends on the OS running the build process. (default behavior.)

### Method 2 - Specify "GeckoDriverPlatform" msbuild property

You can control which platform version of geckodriver will be copied by specifying "GeckoDriverPlatform" MSBuild property.

"GeckoDriverPlatform" MSBuild property can take one of the following values:

- "win32"
- "win64"
- "mac64"
- "mac64arm"
- "linux64"

You can specify "GeckoDriverPlatform" MSBuild property in a project file,

```xml
<PropertyGroup>
  <GeckoDriverPlatform>win32</GeckoDriverPlatform>
</PropertyGroup>
```

or, command-line `-p` option for dotnet build command.

```shell
> dotnet build -p:GeckoDriverPlatform=mac64
```

The specifying "GeckoDriverPlatform" MSBuild property is the highest priority method to control which platform version of geckodriver will be copied.

If you run the following command on Windows OS,

```shell
> dotnet build -r:ubuntu.18.04-x64 -p:GeckoDriverPlatform=mac64
```

The driver file of macOS x64 version will be copied to the output folder.

## How to include the driver file into published files?

"geckodriver(.exe)" isn't included in published files on default configuration. This behavior is by design.

If you want to include "geckodriver(.exe)" into published files, please define `_PUBLISH_GECKODRIVER` compilation symbol.

![define _PUBLISH_GECKODRIVER compilation symbol](https://raw.githubusercontent.com/jsakamoto/nupkg-selenium-webdriver-geckodriver/master/.asset/define_PUBLISH_GECKODRIVER_compilation_symbol.png)

Another way, you can define `PublishGeckoDriver` property with value is "true" in MSBuild file (.csproj, .vbproj, etc...) to publish the driver file instead of define compilation symbol.

```xml
  <Project ...>
    ...
    <PropertyGroup>
      ...
      <PublishGeckoDriver>true</PublishGeckoDriver>
      ...
    </PropertyGroup>
...
</Project>
```

You can also define `PublishGeckoDriver` property from the command line `-p` option for `dotnet publish` command.

```shell
> dotnet publish -p:PublishGeckoDriver=true
```
#### Note

`PublishGeckoDriver` MSBuild property always override the condition of define `_PUBLISH_GECKODRIVER` compilation symbol or not. If you define `PublishGeckoDriver` MSBuild property with false, then the driver file isn't included in publish files whenever define `_PUBLISH_GECKODRIVER` compilation symbol or not.

## Appendix

### Where is geckodriver.exe saved to?

geckodriver(.exe) exists at  
" _{solution folder}_ /packages/Selenium.WebDriver.GeckoDriver. _{ver}_ /**driver**/ _{platform}_"  
folder.

     {Solution folder}/
      +-- packages/
      |   +-- Selenium.WebDriver.GeckoDriver.{version}/
      |       +-- driver/
      |       |   +-- win32
      |       |       +-- geckodriver.exe
      |       |   +-- win64
      |       |       +-- geckodriver.exe
      |       |   +-- mac64
      |       |       +-- geckodriver
      |       |   +-- mac64arm
      |       |       +-- geckodriver
      |       |   +-- linux64
      |       |       +-- geckodriver
      |       +-- build/
      +-- {project folder}/
          +-- bin/
              +-- Debug/
              |   +-- geckodriver(.exe) (copy from above by build process)
              +-- Release/
                  +-- geckodriver(.exe) (copy from above by build process)

 And package installer configure MSBuild task such as .csproj to
 copy geckodriver(.exe) into the output folder during the build process.

## License

The build script (.targets file) in this NuGet package is licensed under [The Unlicense](https://github.com/jsakamoto/nupkg-selenium-webdriver-geckodriver/blob/master/LICENSE).

The binary files of GeckoDriver are licensed under the [Mozilla Public License](https://www.mozilla.org/en-US/MPL/2.0/).
