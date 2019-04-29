# Screenshot.NET

Simple screenshot library for .NET Framework. Allows selection and capture of screen region, similar to Snipping Tool.

## Basic Usage

```c#
// allow user to select and capture screen region
var image = Screenshot.CaptureRegion();

// get a screenshot of given region
var image = Screenshot.CaptureRegion(rect);

// get a screenshot of all screens
var image = Screenshot.CaptureAllScreens();
```