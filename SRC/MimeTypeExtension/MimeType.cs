using Newtonsoft.Json;
namespace MimeTypeExtension
{
    internal class MimeType
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("mime", NullValueHandling = NullValueHandling.Ignore)]
        public string Mime { get; set; }
    }
}

