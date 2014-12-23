using System;
using System.Collections.Generic;
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
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack>
                    {
                        new PlaylistTrack { Title = "title1", Location = "location1" },
                        new PlaylistTrack { Title = "title2", Location = "location2" },
                        new PlaylistTrack { Title = "title3", Location = "location3" },
                        new PlaylistTrack { Title = "title4", Location = "location4" }
                    },
                //Type = PlaylistType.XPSF
                Type = PlaylistType.M3U
            };

            try
            {
                string so = playlist.ToString(playlist.Type);
                Console.WriteLine(so);

                var i = new Playlist(playlist.Type, so);
                Console.WriteLine(i.Tracks.ToList().Count);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }
    }
}
