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

```c#
Uri url = new Uri("http://localhost/test.jpg")
string mimeType = url.MimeType();
Console.WriteLine(mimeType);
```
---
[try it out with Fiddler](https://dotnetfiddle.net/Widget/q4oWyG)

## Supported MIME-Types

https://github.com/ITAgnesmeyer/MimeTypeExtension/blob/master/SRC/MimeTypeExtension/otherTypes.json
