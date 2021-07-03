using System.Collections.Generic;
using System.Xml.Serialization;

namespace MimeExtensionCompere
{

    [XmlRoot(ElementName = "mimeMap")]
    public class MimeMap
    {

        [XmlAttribute(AttributeName = "fileExtension")]
        public string FileExtension { get; set; }

        [XmlAttribute(AttributeName = "mimeType")]
        public string MimeType { get; set; }
    }

    [XmlRoot(ElementName = "staticContent")]
    public class StaticContent
    {

        [XmlElement(ElementName = "mimeMap")] public List<MimeMap> MimeMap { get; set; }

        [XmlAttribute(AttributeName = "lockAttributes")]
        public string LockAttributes { get; set; }
    }
}