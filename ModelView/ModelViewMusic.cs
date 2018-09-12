using mnRelations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.ModelView
{
    public class ModelViewMusic
    {

        public List<Song> MVSongs { get; set; }
        public List<Playlist> MVPlaylists { get; set; }
    }
}
