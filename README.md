# Common Cartridge Dotnet core parser

Dotnet Core Package for parsing LTI & Common Cartridge XML files into C# classes. XDT files downloaded from the [https://www.imsglobal.org/technical-resources](IMS Global Technical Resources) page

## Installation

Install from the Nuget repository [https://www.nuget.org/packages/AndcultureCode.CommonCartridge.Parser/]

## Usage

### Parsing a cartridge manifest file

```
using CommonCartridge.Core;
using CommonCartridge.Core.Constants;
using CommonCartridge.Core.Interfaces;

var fileContent = File.ReadAllText(filename);
var parser = new Parser();
var versionParser = new VersionParser();

// Check Version
var version = versionParser.GetSchemaVersion(fileContent);

if (version == Versions.VERSION_1_0)
{
	// v0 variable contains a fully structured class representing the Common Cartridge 1.0 manifest
	var v0 = parser.FromCCXml<CommonCartridge.Core.Models.v1_0.ManifestType>(fileContent, directoryPath);
} else if (version == Versions.VERSION_1_1)
{
	// v1 variable contains a fully structured class representing the Common Cartridge 1.1 manifest
	var v1 = parser.FromCCXml<CommonCartridge.Core.Models.v1_1.ManifestType>(fileContent, DirectoryPath);
} else if (version == Versions.VERSION_1_2)
{
	// v2 variable contains a fully structured class representing the Common Cartridge 1.2 manifest
	var v2 = parser.FromCCXml<CommonCartridge.Core.Models.v1_2.ManifestType>(fileContent, DirectoryPath);
} else if (version == Versions.VERSION_1_3)
{
	// v3 variable contains a fully structured class representing the Common Cartridge 1.3 manifest
	var v3 = parser.FromCCXml<CommonCartridge.Core.Models.v1_3.ManifestType>(fileContent, DirectoryPath);
}
```

### Parsing an LTI file

```
using CommonCartridge.Core;
using CommonCartridge.Core.Constants;
using CommonCartridge.Core.Interfaces;

var fileContent = File.ReadAllText(filename);
var parser = new Parser();
var versionParser = new VersionParser();

// Check Version
var version = versionParser.GetSchemaVersion(fileContent);

if (version == Versions.VERSION_1_0)
{
	// v0 variable contains a fully structured class representing the LTI 1.0 file
	var v0 = _parser.FromLTIXml<CommonCartridge.Core.Models.v1_0.CartridgeBasicLTILinkType>(fileContent);
} else if (version == Versions.VERSION_1_1)
{
	// v1 variable contains a fully structured class representing the LTI 1.1 file
	var v1 = _parser.FromLTIXml<CommonCartridge.Core.Models.v1_1.CartridgeBasicLTILinkType>(fileContent);
} else if (version == Versions.VERSION_1_2)
{
	// v1_1 variable contains a fully structured class representing the LTI 1.1.2 file
	var v1_1 = _parser.FromLTIXml<CommonCartridge.Core.Models.v1_1_1.CartridgeBasicLTILinkType>(fileContent);
}
```

## Interfaces

### IParser

Method | Return | Description
----------|------|------------
FromLTIFile&lt;T&gt; | BasicLTIParserResult | Same as FromLTIXml, but also loads file from specified path before parsing
FromLTIXml&lt;T&gt; | BasicLTIParserResult | Loads XML into XDocument and deserializes to provided LTI class
FromCCArchive&lt;T&gt; | CCParserResult | Verifies extension of archive, attemps to unzip into a temp directory, and looks for an imsmanifest.xml file to pass to FromCCFile
FromCCFile&lt;T&gt; | CCParserResult | Same as FromCCXml, but also loads file from specified path before parsing
FromCCXml&lt;T&gt; | CCParserResult | Loads XML into XDocument and deserializes to provided CC class

### IVersionParser

Method | Return | Description
----------|------|------------
GetSchemaVersionFromFile | string | Same as GetSchemaVersion, but also loads file from specified path before parsing
GetSchemaVersion | string | Loads XML into XDocument attempts to read version string from XML schemaversion attribute