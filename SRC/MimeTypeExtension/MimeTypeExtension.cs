using System.IO;
using System.Reflection;

namespace MimeTypeExtension
{
    public static class MimeTypeExtension
    {
        private static MimeTypeList _MimeTypesList; 
        static MimeTypeExtension()
        {
            FillTypeList();
        }
        private static void FillTypeList()
        {
            if(_MimeTypesList != null)
                return;

            Assembly assembly = typeof(MimeTypeList).GetTypeInfo().Assembly;
            var names = assembly.GetManifestResourceNames();
            var stream = assembly.GetManifestResourceStream("MimeTypeExtension.otherTypes.json");
            string jsonString = "";
            using(var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }
            _MimeTypesList = Newtonsoft.Json.JsonConvert.DeserializeObject<MimeTypeList>(jsonString);

        }
        /// <summary>
        /// Get the MimeType from File-Extension
        /// </summary>
        /// <param name="input">FileInfo</param>
        /// <returns>Returns the MIME-Type eg. Image/jpg</returns>
        public static string MimeType(this FileInfo input)
        {
           string extension = input.Extension;
           var mimeType = _MimeTypesList.MimeTypes.Find(x=> x.Type == extension);
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

