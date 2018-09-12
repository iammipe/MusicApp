using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mnRelations.Models;
using mnRelations.Data;

namespace mnRelations.Services
{
    public class SqlMusicData : IMusic
    {
        private MusicDBContext _context;

        public SqlMusicData(MusicDBContext context)
        {
            _context = context;
        }

        
        public List<Playlist> Get()
        {
            return _context.Playlists.OrderBy(p => p.PlaylistID).ToList();
        }
    }
}
