using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaylistSharpLib.XPSF
{
    class XpsfPlaylist : IPlaylist
    {
        public IEnumerable<PlaylistSharpLib.PlaylistTrack> Tracks { get; set; }

        #region converter
        private static IEnumerable<PlaylistSharpLib.PlaylistTrack> ToBase(IEnumerable<PlaylistTrack> xpsfList)
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
                   select new PlaylistTrack
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
            Tracks = ToBase(ClearEmptyTrack(xpsfPlaylist.TrackList));
        }

        public XpsfPlaylist(IEnumerable<PlaylistSharpLib.PlaylistTrack> tracks)
        {
            Tracks = from item in tracks
                     where !String.IsNullOrWhiteSpace(item.Location)
                     select item;
        }

        #endregion

        #region helper

        private static IEnumerable<PlaylistTrack> ClearEmptyTrack(IEnumerable<PlaylistTrack> xpsfPlaylist)
        {
            return from item in xpsfPlaylist
                   let isEmpty = String.IsNullOrWhiteSpace(item.Location)
                   where !isEmpty
                   select item;
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
