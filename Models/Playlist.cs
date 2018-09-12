using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.Models
{
    public class Playlist
    {
        public Playlist()
        {
            SongPlaylists = new List<SongPlaylist>();
        }

        public int PlaylistID { get; set; }
        public string PlaylistName { get; set; }
        public string PlaylistImage { get; set; }

        public ICollection<SongPlaylist> SongPlaylists { get; set; }
    }
}