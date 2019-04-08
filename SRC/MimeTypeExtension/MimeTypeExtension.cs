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
           string exteion = input.Extension;
           var mimeType = _MimeTypesList.MimeTypes.Find(x=> x.Type == exteion);
            if(mimeType == null)
                return "";
            return mimeType.Mime;
        }
    }
}

