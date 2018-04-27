*** Nuget Publishing Steps ***

In order to build the .nupkg file, edit the PackageVersion and Version in ZoomClient.csproj
And run this command in a PowerShell window pathed to the folder that the .csproj file is in.

dotnet pack -c Release