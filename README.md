# Screenshot.NET

Simple screenshot library for .NET Framework. Allows selection and capture of screen region, similar to Snipping Tool.

## Requirements

* .NET 4.6.2+

## Installation

```
PM> Install-Package GI.Screenshot
```

## Usage

```c#
// allow user to select and capture screen region
var image = Screenshot.CaptureRegion();

// get a screenshot of given region
var image = Screenshot.CaptureRegion(rect);

// get a screenshot of all screens
var image = Screenshot.CaptureAllScreens();
```

## Multiple monitors with different scale factors

The application must enable **per-monitor DPI awareness** in order for the region selection to work properly on a multi-monitor setup where not all monitors use the same scale factor.

It is recommended that to be [set in the application manifest](https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/mt846517(v%3Dvs.85)#setting-default-awareness-with-the-application-manifest):

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
