# Screenshot.NET

Simple screenshot library for .NET. Allows selection and capture of screen region, similar to Snipping Tool.

## Requirements

* .NET Framework 4.6.2+, .NET 6+, or .NET 8+
* Windows only (uses WPF and System.Drawing)

## Installation

```
dotnet add package GI.Screenshot
```

Or via Package Manager Console:
```
PM> Install-Package GI.Screenshot
```

## Supported Frameworks

The library targets multiple frameworks:
- .NET Framework 4.6.2 (`net462`)
- .NET 6.0 Windows (`net6.0-windows`)
- .NET 8.0 Windows (`net8.0-windows`)

NuGet will automatically select the appropriate version for your project.

## Usage

```c#
using GI.Screenshot;

// allow user to select and capture screen region
var image = Screenshot.CaptureRegion();

// customize the selection UI
var options = new ScreenshotOptions
{
    BackgroundOpacity = 0.5,
    SelectionRectangleBorderBrush = Brushes.Red
};
var image = Screenshot.CaptureRegion(options);

// get a screenshot of given region
var image = Screenshot.CaptureRegion(rect);

// get a screenshot of all screens
var image = Screenshot.CaptureAllScreens();
```

The returned `BitmapSource` can be used directly in WPF or saved to disk.

## Multiple monitors with different scale factors

The application must enable **per-monitor DPI awareness** in order for the region selection to work properly on a multi-monitor setup where not all monitors use the same scale factor.

It is recommended to [set this in the application manifest](https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/mt846517(v%3Dvs.85)#setting-default-awareness-with-the-application-manifest):

```xml
<?xml version="1.0" encoding="utf-8"?>

<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">

  <application xmlns="urn:schemas-microsoft-com:asm.v3">
    <windowsSettings>
      <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">True/PM</dpiAware>
      <dpiAwareness xmlns="http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2, PerMonitor</dpiAwareness>
    </windowsSettings>
  </application>

</assembly>
```

## Building

Build the library:
```bash
dotnet build Screenshot.sln
```

Create NuGet package:
```bash
dotnet pack Screenshot/Screenshot.csproj -c Release -o Releases
```

## License

MIT License - see [LICENSE](LICENSE) file for details
