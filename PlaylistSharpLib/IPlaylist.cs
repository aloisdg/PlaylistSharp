using System.Collections.Generic;

namespace PlaylistSharpLib
{
    public interface IPlaylist
    {
        IEnumerable<PlaylistTrack> Tracks { get; set; }

        string ToString();
    }
}