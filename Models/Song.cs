using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.Models
{
    public class Song
    {
        public Song()
        {
            SongPlaylists = new List<SongPlaylist>();
        }

        public int SongID { get; set; }
        public string NameOfSong { get; set; }
        public string NameOfArtist { get; set; }
        public string SongURL { get; set; }
        public string PictureURL { get; set; } 
        public string Duration { get; set; }
        public string FunFact { get; set; }

        public ICollection<SongPlaylist> SongPlaylists { get; set; }
    }
}
