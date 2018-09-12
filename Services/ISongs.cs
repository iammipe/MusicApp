using mnRelations.Models;
using mnRelations.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.Services
{
    public interface ISongs
    {
        //ModelViewMusic GetAllData();

        void Add(Song song); // CREATE SONG
        List<Song> ReadAll(); // READ SONG
        void Edit(Song editedSong); // UPDATE SONG
        void Delete(int songId); // DELETE SONG

        IEnumerable<Song> GetAllSongsAZ();
        Song GetSpecificSong(int id);
        string GetURL(int id);
        Song GetFunFact(int id);
    }
}