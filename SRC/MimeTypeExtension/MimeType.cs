
using ZeroDep;
namespace MimeTypeExtension
{
    internal class MimeType
    {
        [Json("type")]
        public string Type { get; set; }

        [Json("mime")]
        public string Mime { get; set; }
    }
}

