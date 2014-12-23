using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlaylistSharpLib.M3U
{
    class M3UPlaylist : IPlaylist
    {
        public IEnumerable<PlaylistSharpLib.PlaylistTrack> Tracks { get; set; }

        #region cleaner
        private static string RemoveHeader(string source)
        {
            return source.Replace("#EXTM3U", String.Empty).Trim();
        }

        private static IEnumerable<string> RemoveComments(IEnumerable<string> lines)
        {
            return lines.Where(line => !line.StartsWith("#EXTREM:"));
        }

        private static IEnumerable<string> Clean(string m3u)
        {
            return RemoveComments(RemoveHeader(m3u).Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));
        }
        #endregion

        #region builder

        private static Information BuildInformation(string line)
        {
            var info = line.Replace("#EXTINF:", String.Empty);
            var index = info.IndexOf(',');
            return new Information
            {
                Duration = info.Substring(0, index),
                Title = info.Substring(index + 1)
            };
        }

        private static PlaylistTrack BuildTrack(string information, string location)
        {
            return new PlaylistTrack
                {
                    Information = BuildInformation(information),
                    Location = location
                };
        }

        private static M3U BuildM3U(string m3u)
        {
            var lines = new List<string>(Clean(m3u));
            if (lines.Count % 2 != 0)
                throw new FormatException("m3u");

            var tracks = new List<PlaylistTrack>();
            for (var i = 0; i < lines.Count; i += 2)
                tracks.Add(BuildTrack(lines[i], lines[i + 1]));

            return new M3U
            {
                Version = "#EXTM3U",
                TrackList = tracks.ToArray()
            };
        }
        
        #endregion

        #region converter
        private static IEnumerable<PlaylistSharpLib.PlaylistTrack> ToBase(IEnumerable<PlaylistTrack> xpsfList)
        {
            return from track in xpsfList
                   select new PlaylistSharpLib.PlaylistTrack
                   {
                       Title = track.Information.Title,
                       Location = track.Location
                   };
        }

        private static IEnumerable<PlaylistTrack> FromBase(IEnumerable<PlaylistSharpLib.PlaylistTrack> playlist)
        {
            return from track in playlist
                   select new PlaylistTrack
                   {
                       Information = new Information
                       {
                           Duration = "-1",
                           Title = track.Title
                       },
                       Location = track.Location
                   };
        }
        #endregion

        #region ctor

        public M3UPlaylist(string m3u)
        {
            Tracks = ToBase(BuildM3U(m3u).TrackList);
        }

        public M3UPlaylist(IEnumerable<PlaylistSharpLib.PlaylistTrack> tracks)
        {
            Tracks = tracks;
        }

        #endregion

        public override string ToString()
        {
            var s = new StringBuilder(String.Format("#EXTM3U{0}{0}",
                Environment.NewLine));  
            var tracks = FromBase(Tracks);
            foreach (var playlistTrack in tracks)
                s.AppendFormat("#EXTINF:{0}, {1}{2}{3}{2}{2}",
                    playlistTrack.Information.Duration,
                    playlistTrack.Information.Title,
                    Environment.NewLine,
                    playlistTrack.Location);
            return s.ToString();
        }
    }
}
