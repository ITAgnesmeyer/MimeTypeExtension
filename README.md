# MimeTypeExtension
Extension for FileInfo. Returns the matching MIME type of a file.

NuGet:
https://www.nuget.org/packages/MimeTypeExtension/1.0.0

# Usage
```c#
FileInfo fi = new FileInfo("test.jpg")
string mimeType = fi.MimeType();
Console.WriteLine(mimeType);
```
## Supported MIME-Types

https://github.com/ITAgnesmeyer/MimeTypeExtension/blob/master/SRC/MimeTypeExtension/otherTypes.json
