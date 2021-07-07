# MimeTypeExtension
Extension for FileInfo. Returns the matching MIME type of a file.

# Json Serialization
Internally, the JSON resources are serialized with the following great tool:
https://github.com/smourier/ZeroDepJson 

# NuGet:
https://www.nuget.org/packages/MimeTypeExtension

# Usage
```c#
FileInfo fi = new FileInfo("test.jpg")
string mimeType = fi.MimeType();
Console.WriteLine(mimeType);
```

```c#
Uri url = new Uri("http://localhost/test.jpg")
string mimeType = url.MimeType();
Console.WriteLine(mimeType);
```
---
[try it out with Fiddler](https://dotnetfiddle.net/Widget/q4oWyG)

For whom the currently 894 MIME types are not enough. Can store own MIME types. 
The static function AddOrUpdateMimeType is now available for this. 
With this function you can change existing MIME types or add new ones. 

```c#
var result = MimeTypeExtension.AddOrUpdateMimeType(".aa", "audio/audible");
```

## Supported MIME-Types

https://github.com/ITAgnesmeyer/MimeTypeExtension/blob/master/SRC/MimeTypeExtension/otherTypes.json
