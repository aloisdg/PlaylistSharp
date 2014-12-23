using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistSharpLib.XPSF
{
    class XpsfPlaylist : IPlaylist
    {
        public IEnumerable<PlaylistSharpLib.PlaylistTrack> Tracks { get; set; }

        #region converter
        private static IEnumerable<PlaylistSharpLib.PlaylistTrack> ToBase(IEnumerable<PlaylistSharpLib.XPSF.PlaylistTrack> xpsfList)
        {
            return from track in xpsfList
                 select new PlaylistSharpLib.PlaylistTrack
                 {
                     Title = track.Title,
                     Location = track.Location
                 };
        }

        private static IEnumerable<PlaylistTrack> FromBase(IEnumerable<PlaylistSharpLib.PlaylistTrack> playlist)
        {
            return from track in playlist
                select new PlaylistSharpLib.XPSF.PlaylistTrack
                {
                    Title = track.Title,
                    Location = track.Location
                };
        }
        #endregion

        #region ctor

        public XpsfPlaylist(string xpsf)
        {
            var xpsfPlaylist = Serializer.DeserializeFromXml<Xpsf>(xpsf);
            Tracks = ToBase(xpsfPlaylist.TrackList.AsEnumerable());
        }

        public XpsfPlaylist(IEnumerable<PlaylistSharpLib.PlaylistTrack> tracks)
        {
            Tracks = tracks;
        }

        #endregion

        public override string ToString()
        {
            return Serializer.SerializeToXml(
                new Xpsf
                {
                    TrackList = FromBase(Tracks).ToArray(),
                    Version = 1
                });
        }
    }
}
