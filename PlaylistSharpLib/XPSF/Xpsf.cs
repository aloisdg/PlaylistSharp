using System.Xml.Serialization;

namespace PlaylistSharpLib.XPSF
{
    // http://validator.xspf.org/
    // http://www.xspf.org/specs/

    [XmlType(AnonymousType = true, Namespace = "http://xspf.org/ns/0/")]
    [XmlRoot(
        Namespace = "http://xspf.org/ns/0/",
        ElementName = "playlist",
        IsNullable = false)]
    public class Xpsf
    {
        [XmlArrayItem("track", IsNullable = false)]
        [XmlArray(ElementName = "trackList")]
        public PlaylistTrack[] TrackList { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public int Version { get; set; }
    }

    [XmlType(
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
