using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PlaylistSharpLib;

namespace PlaylistSharpTest.Unit
{
    [TestFixture]
    public class SerialTest
    {
        [Test]
        public void Playlist_Avec3Elem_XPSF()
        {
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack>
                {
                    new PlaylistTrack {Title = "title1", Location = "location1"},
                    new PlaylistTrack {Title = string.Empty, Location = "location2"},
                    new PlaylistTrack {Title = null, Location = "location3"}
                },
                Type = PlaylistType.XPSF
            };

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);

            Assert.AreEqual(list, list2);
            Assert.AreEqual(3, playlist2.Tracks.ToList().Count);
        }

        [Test]
        public void Playlist_Avec3Elem_M3U()
        {
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack>
                {
                    new PlaylistTrack {Title = "title1", Location = "location1"},
                    new PlaylistTrack {Title = string.Empty, Location = "location2"},
                    new PlaylistTrack {Title = null, Location = "location3"}
                },
                Type = PlaylistType.M3U
            };

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);

            Assert.AreEqual(list, list2);
            Assert.AreEqual(3, playlist2.Tracks.ToList().Count);
        }

        [Test]
        [ExpectedException]
        public void Playlist_AvecNullElem_XPSF()
        {
            var playlist = new Playlist
            {
                Tracks = null,
                Type = PlaylistType.XPSF
            };

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);
        }

        [Test]
        [ExpectedException]
        public void Playlist_AvecNullElem_M3U()
        {
            var playlist = new Playlist
            {
                Tracks = null,
                Type = PlaylistType.M3U
            };

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);
        }

        [Test]
        [ExpectedException]
        public void Playlist_Avec0ElemValide_XPSF()
        {
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack>
                {
                    new PlaylistTrack {Title = string.Empty, Location = null},
                    new PlaylistTrack {Title = string.Empty, Location = string.Empty},
                    new PlaylistTrack {Title = null, Location = null},
                    new PlaylistTrack {Title = null, Location = string.Empty}
                },
                Type = PlaylistType.XPSF
            };

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);
        }

        [Test]
        [ExpectedException]
        public void Playlist_Avec0ElemValide_M3U()
        {
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack>
                {
                    new PlaylistTrack {Title = string.Empty, Location = null},
                    new PlaylistTrack {Title = string.Empty, Location = string.Empty},
                    new PlaylistTrack {Title = null, Location = null},
                    new PlaylistTrack {Title = null, Location = string.Empty}
                },
                Type = PlaylistType.M3U
            };

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);
        }
        [Test]
        public void Playlist_Avec10Elem_XPSF()
        {
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack>
                {
                    new PlaylistTrack {Title = "title1", Location = "location1"},
                    new PlaylistTrack {Title = string.Empty, Location = "location2"},
                    new PlaylistTrack {Title = null, Location = "location3"},
                    new PlaylistTrack {Title = "title2", Location = "location4"},
                    new PlaylistTrack {Title = "title3", Location = null},
                    new PlaylistTrack {Title = "title4", Location = "location5"},
                    new PlaylistTrack {Title = "title5", Location = "location6"},
                    new PlaylistTrack {Title = "title6", Location = string.Empty},
                    new PlaylistTrack {Title = null, Location = "location7"},
                    new PlaylistTrack {Title = "", Location = "location8"},
                    new PlaylistTrack {Title = string.Empty, Location = "location9"},
                    new PlaylistTrack {Title = "title7", Location = ""},
                    new PlaylistTrack {Title = null, Location = "location10"}
                },
                Type = PlaylistType.XPSF
            };

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);

            Assert.AreEqual(list, list2);
            Assert.AreEqual(10, playlist2.Tracks.ToList().Count);
        }

        [Test]
        public void Playlist_Avec10Elem_M3U()
        {
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack>
                {
                    new PlaylistTrack {Title = "title1", Location = "location1"},
                    new PlaylistTrack {Title = string.Empty, Location = "location2"},
                    new PlaylistTrack {Title = null, Location = "location3"},
                    new PlaylistTrack {Title = "title2", Location = "location4"},
                    new PlaylistTrack {Title = "title3", Location = null},
                    new PlaylistTrack {Title = "title4", Location = "location5"},
                    new PlaylistTrack {Title = "title5", Location = "location6"},
                    new PlaylistTrack {Title = "title6", Location = string.Empty},
                    new PlaylistTrack {Title = null, Location = "location7"},
                    new PlaylistTrack {Title = "", Location = "location8"},
                    new PlaylistTrack {Title = string.Empty, Location = "location9"},
                    new PlaylistTrack {Title = "title7", Location = ""},
                    new PlaylistTrack {Title = null, Location = "location10"}                },
                Type = PlaylistType.M3U
            };

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);

            Assert.AreEqual(list, list2);
            Assert.AreEqual(10, playlist2.Tracks.ToList().Count);
        }

        [Test]
        public void Playlist_Avec460Elem_XPSF()
        {
            const int nbTrack = 460;
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack>() ,
                Type = PlaylistType.XPSF
            };

            var listTrack = playlist.Tracks.ToList();
            for (int i = 0; i < nbTrack; i++)
                listTrack.Add(new PlaylistTrack {Title = "Title" + i, Location = "location" + i });
            playlist.Tracks = listTrack;

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);

            Assert.AreEqual(list, list2);
            Assert.AreEqual(nbTrack, playlist2.Tracks.ToList().Count);
        }

        [Test]
        public void Playlist_Avec460Elem_M3U()
        {
            const int nbTrack = 460;
            var playlist = new Playlist
            {
                Tracks = new List<PlaylistTrack> (),
                Type = PlaylistType.M3U
            };
            var listTrack = playlist.Tracks.ToList();
            for (int i = 0; i < nbTrack; i++)
                listTrack.Add(new PlaylistTrack { Title = "Title" + i, Location = "location" + i });
            playlist.Tracks = listTrack;

            string list = playlist.ToString(playlist.Type);

            var playlist2 = new Playlist(playlist.Type, list);

            string list2 = playlist2.ToString(playlist2.Type);

            Assert.AreEqual(list, list2);
            Assert.AreEqual(nbTrack, playlist2.Tracks.ToList().Count);
        }


    }
}