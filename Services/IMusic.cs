using mnRelations.Models;
using mnRelations.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.Services
{
    public interface IMusic
    {
        List<Playlist> Get();
    }
}
