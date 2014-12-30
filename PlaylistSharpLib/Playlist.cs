using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlaylistSharpLib.M3U;
using PlaylistSharpLib.XPSF;

namespace PlaylistSharpLib
{
    public class Playlist : IPlaylist
    {
        public IEnumerable<PlaylistTrack> Tracks { get; set; }
        public PlaylistType Type { get; set; }

        public string RawData { get; set; }

        public Playlist()
        {
            Tracks = new List<PlaylistTrack>();
            Type = PlaylistType.UNKNOW;
            RawData = String.Empty;
        }

        public Playlist(PlaylistType playlistType, string data)
        {
            if (playlistType != PlaylistType.XPSF &&
                playlistType != PlaylistType.M3U)
                throw new NotImplementedException("Format not implemented yet.");

            var playlist = playlistType == PlaylistType.XPSF
                ? (IPlaylist)new XpsfPlaylist(data)
                : (IPlaylist)new M3UPlaylist(data);

            Tracks = playlist.Tracks;
            Type = playlistType;
            RawData = data;
        }

        public override string ToString()
        {
            return this.RawData;
        }

        public string ToString(PlaylistType playlistType)
        {
            if (Type == PlaylistType.UNKNOW)
                return String.Empty;
            if (!Tracks.Any())
                throw new Exception("No tracks found.");
            if (playlistType != PlaylistType.XPSF &&
                playlistType != PlaylistType.M3U)
                throw new NotImplementedException("Format not implemented yet.");


            var playlist = playlistType == PlaylistType.XPSF
             ? (IPlaylist)new XpsfPlaylist(Tracks)
             : (IPlaylist)new M3UPlaylist(Tracks);
            return playlist.ToString();

            //return RawData;
        }
    }
}
