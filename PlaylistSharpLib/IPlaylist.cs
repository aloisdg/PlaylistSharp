using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace PlaylistSharpLib
{
    public interface IPlaylist
    {
        IEnumerable<PlaylistTrack> Tracks { get; set; }

        string ToString();
    }
}