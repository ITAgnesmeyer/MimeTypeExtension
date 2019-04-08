# MimeTypeExtension
Extension for FileInfo to get responding MIME-Type
# Usage
```c#
FileInfo fi = new FileInfo("test.jpg")
string mimeType = fi.MimeType();
Console.WriteLine(mimeType);
```
