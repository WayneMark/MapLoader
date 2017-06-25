# MapLoader

![](https://raw.githubusercontent.com/DevChache/MapLoader/master/JsonMapLoader/JsonMapLoader_icon_256x256.png)

A simple class library supporting loading map files from either embedded resources or file system

## Requirement
- .NET Framework (standard) (>= 4.5)
- Newtonsoft.Json (>= 10.0.3)

## Installation
### NuGet package management

```powershell
PM> Install-Package JsonMapLoader
```

In this way, you will have the convenience of a more active upgrading policy.

### Direct reference
You may download source code (<= 1.0.2) to compile and reference yourself. Or you can download the latest release binary (Platform=Any CPU) (>= 1.0.3) and reference manually. This method will only add support for current downloaded version and you must upgrade it yourself once the new build released.

## How to use
1. Add reference to this class library
2. Invoke static method `Load()` with the first parameter specifics the path or resource name and the second one decide whether to load resource or file system.

## Info
DevChache @NCEPU

[Contact Me](mailto://yangzd1996@outlook.com)

with **Yuan**
