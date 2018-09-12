using mnRelations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.ModelView
{
    public class ModelViewPlaylist
    {
        public Playlist Playlist { get; set; }
        public List<Song> Songs { get; set; }
    }
}
