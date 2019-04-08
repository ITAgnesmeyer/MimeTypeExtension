using Newtonsoft.Json;
using System.Collections.Generic;
namespace MimeTypeExtension
{
    internal  class MimeTypeList
    {
        [JsonProperty("mime_types", NullValueHandling = NullValueHandling.Ignore)]
        public List<MimeType> MimeTypes { get; set; }
    }
}

