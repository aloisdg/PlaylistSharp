namespace PlaylistSharpLib.M3U
{
    public class M3U
    {
        public PlaylistTrack[] TrackList { get; set; }
        public string Version { get; set; }
    }

    public class PlaylistTrack
    {
        public Information Information { get; set; }
        public string Location { get; set; }
    }
     
    public class Information
    {
        public string Duration { get; set; }
        public string Title { get; set; }
    }
}
