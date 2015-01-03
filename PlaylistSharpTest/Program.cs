using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlaylistSharpLib;

namespace PlaylistSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    var playlist = BuildPlaylist(i%2 == 0);

                    string so = playlist.ToString(playlist.Type);
                    Console.WriteLine(so);

                    var pList = new Playlist(playlist.Type, so);
                    Console.WriteLine(pList.Tracks.ToList().Count);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadLine();
        }

        static Playlist BuildPlaylist(bool b)
        {
            return new Playlist
            {
                Tracks = new List<PlaylistTrack>
                    {
                        new PlaylistTrack { Title = "title1", Location = "location1" },
                        new PlaylistTrack { Title = "title2", Location = "location2" },
                        new PlaylistTrack { Title = null, Location = "location2" },
                        new PlaylistTrack { Title = "title2", Location = null },
                        new PlaylistTrack { Title = "title3", Location = String.Empty },
                        new PlaylistTrack { Title = String.Empty, Location = "location4" }
                    },
                Type =  b ? PlaylistType.XPSF : PlaylistType.M3U
            }; 
        }
    }
}
