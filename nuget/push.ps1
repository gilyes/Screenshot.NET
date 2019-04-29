param (
	[Parameter(Mandatory=$true)]
    [string]$version
)

nuget push $PSScriptRoot\..\Releases\GI.Screenshot.$version.nupkg -Source https://api.nuget.org/v3/index.json