using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using ZeroDep;


namespace MimeTypeExtension
{

    
    /// <summary>
    /// MIME-Type Extension for FileInfo and Url
    /// </summary>
    public static class MimeTypeExtension
    {
        private static MimeTypeList _mimeTypesList; 
        static MimeTypeExtension()
        {
            FillTypeList();
        }
        private static void FillTypeList()
        {
            if(_mimeTypesList != null)
                return;

            Assembly assembly = typeof(MimeTypeList).GetTypeInfo().Assembly;
            var names = assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream("MimeTypeExtension.otherTypes.json");
            if (stream == null)
                throw new FileNotFoundException("Could not load Resource");
            string jsonString = "";
            using(var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            _mimeTypesList =
                Json.Deserialize<MimeTypeList>(
                    jsonString); //Newtonsoft.Json.JsonConvert.DeserializeObject<MimeTypeList>(jsonString);

        }
        /// <summary>
        /// You can Add or update your List of MIMES
        /// </summary>
        /// <param name="fileExtension">File extension eg. ".exe". The extension must start with  "."</param>
        /// <param name="mime">MIME Type string eg. "application/octet-stream". The string must contain "/"</param>
        /// <returns></returns>
        public static bool AddOrUpdateMimeType(string fileExtension, string mime)
        {
            if (string.IsNullOrEmpty(fileExtension))
                throw new ArgumentNullException(nameof(fileExtension),"fileExtension cannot be null");

            if (string.IsNullOrEmpty(mime))
                throw new ArgumentNullException(nameof(mime), "mime cannot be null");
            if (!fileExtension.StartsWith("."))
                throw new ArgumentException("fileExtension must start with a \".\"", nameof(fileExtension));

            if (!mime.Contains("/"))
                throw new ArgumentException("MIME must contain \"/\"", nameof(mime));

            if (_mimeTypesList.MimeTypes.Any(x => x.Type == fileExtension))
            {
                var mimeType = _mimeTypesList.MimeTypes.Find(x => x.Type == fileExtension);
                if (mimeType == null) return false;
                mimeType.Mime = mime;
                return true;

            }
            _mimeTypesList.MimeTypes.Add(new MimeType(){Type = fileExtension, Mime = mime});
            return true;
        }
        /// <summary>
        /// Get MimeType from URL
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string MimeType(this Uri uri)
        {
            string path = uri.GetComponents(UriComponents.Path, UriFormat.Unescaped);
            FileInfo fi = new FileInfo(path);
            return fi.MimeType();
        }

        /// <summary>
        /// Get the MimeType from URL.
        /// If MimeType not found you can give a default MimeType
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="defaultMime"></param>
        /// <returns></returns>
        public static string MimeTypeOrDefault(this Uri uri, string defaultMime = "application/octet-stream")
        {
            string path = uri.GetComponents(UriComponents.Path, UriFormat.Unescaped);
            FileInfo fi = new FileInfo(path);
            return fi.MimeTypeOrDefault(defaultMime);
        }

        /// <summary>
        /// Get the MimeType from File-Extension
        /// </summary>
        /// <param name="input">FileInfo</param>
        /// <returns>Returns the MIME-Type eg. Image/jpg</returns>
        public static string MimeType(this FileInfo input)
        {
           string extension = input.Extension;
           var mimeType = _mimeTypesList.MimeTypes.Find(x=> x.Type == extension);
            if(mimeType == null)
                return "";
            return mimeType.Mime;
        }
        /// <summary>
        /// Get the MimeType from File-Extension.
        /// If MimeType not found you can give a default MimeType
        /// </summary>
        /// <param name="input">FileInfo</param>
        /// <param name="defaultMime">Default MIME</param>
        /// <returns>Returns the MIME-Type eg. Image/jpg</returns>
        public static string MimeType(this FileInfo input, string defaultMime)
        {
            var mimeType = MimeType(input);
            if (string.IsNullOrEmpty(mimeType))
                mimeType = defaultMime;
            return mimeType;
        }
        /// <summary>
        /// Get the MimeType from File-Extension.
        /// If MIME not found you can give a default MIME
        /// If you don't give a default value the Default is:
        /// application/octet-stream
        /// </summary>
        /// <param name="input">FileInfo</param>
        /// <param name="defaultMime">Default MIME => default application/octet-stream</param>
        /// <returns>Returns the MIME-Type eg. Image/jpg or application/octet-stream</returns>
        public static string MimeTypeOrDefault(this FileInfo input, string defaultMime = "application/octet-stream")
        {
            return MimeType(input, defaultMime);
        }
    }
}

