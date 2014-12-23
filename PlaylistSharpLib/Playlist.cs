using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistSharpLib.M3U;
using PlaylistSharpLib.XPSF;

namespace PlaylistSharpLib
{
    public class Playlist : IPlaylist
    {
        public IEnumerable<PlaylistTrack> Tracks { get; set; }
        public PlaylistType Type { get; set; }

        public Playlist()
        {
            Tracks = new List<PlaylistTrack>();
            Type = PlaylistType.UNKNOW;
        }

        public Playlist(PlaylistType playlistType, string data)
        {
            if (playlistType != PlaylistType.XPSF &&
                playlistType != PlaylistType.M3U)
                throw new NotImplementedException("Format not implemented yet.");

            //var playlist = playlistType == PlaylistType.XPSF
            //    ? (IPlaylist)new XpsfPlaylist(data)
            //    : (IPlaylist)new M3UPlaylist(data);

            var playlist = new M3UPlaylist(data);

            Tracks = playlist.Tracks;
            Type = playlistType;
        }

        public string ToString(PlaylistType playlistType)
        {
            if (Type == PlaylistType.UNKNOW)
                return String.Empty;
            if (playlistType != PlaylistType.XPSF &&
                playlistType != PlaylistType.M3U)
                throw new NotImplementedException("Format not implemented yet.");
            if (!Tracks.Any())
                throw new Exception();

            var playlist = playlistType == PlaylistType.XPSF
             ? (IPlaylist)new XpsfPlaylist(Tracks)
             : (IPlaylist)new M3UPlaylist(Tracks);
            return playlist.ToString();
        }
    }
}
