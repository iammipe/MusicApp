using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.Models
{
    public class SongPlaylist
    {
        public int SongID { get; set; }
        public int PlaylistID { get; set; }
        public Song Song { get; set; }
        public Playlist Playlist { get; set; }
    }
}
