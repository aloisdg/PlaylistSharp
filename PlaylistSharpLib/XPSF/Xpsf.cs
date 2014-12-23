using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PlaylistSharpLib.XPSF
{
    // http://validator.xspf.org/
    // http://www.xspf.org/specs/

    [XmlType(AnonymousType = true, Namespace = "http://xspf.org/ns/0/")]
    [XmlRootAttribute(
        Namespace = "http://xspf.org/ns/0/",
        ElementName = "playlist",
        IsNullable = false)]
    public class Xpsf
    {
        [XmlArrayItem("track", IsNullable = false)]
        [XmlArray(ElementName = "trackList")]
        public PlaylistTrack[] TrackList { get; set; }

        [XmlAttributeAttribute(AttributeName = "version")]
        public int Version { get; set; }
    }

    [XmlTypeAttribute(
        AnonymousType = true,
        Namespace = "http://xspf.org/ns/0/",
        TypeName = "playlistTrack")]
    public class PlaylistTrack
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("location")]
        public string Location { get; set; }
    }
}
