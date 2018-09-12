using mnRelations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mnRelations.Models;
using mnRelations.ModelView;
using mnRelations.Data;

namespace mnRelations.DataSql
{
    public class SqlSongsData : ISongs
    {
        private MusicDBContext context;

        public SqlSongsData(MusicDBContext _context)
        {
            context = _context;
        }

        public void Add(Song song)
        {
            context.Add(song);
            context.SaveChanges();
        }

        public void Delete(int songId)
        {
            var toDeleteSong = context.Songs.FirstOrDefault(e => e.SongID == songId);
            if (toDeleteSong != null)
            {
                context.Songs.Remove(toDeleteSong);
                context.SaveChanges();
            }
        }

        public List<Song> ReadAll()
        {
            return (context.Songs.ToList());
        }

        public IEnumerable<Song> GetAllSongsAZ()
        {
            return context.Songs.OrderBy(a => a.NameOfArtist).ThenBy(a => a.NameOfSong).ThenBy(a => a.SongID);
        }

        public Song GetSpecificSong(int id)
        {
            var specificSong = context.Songs.FirstOrDefault(a => a.SongID == id);

            return specificSong;
        }

        public void Edit(Song editedSong)
        {
            var editingSong = context.Songs.FirstOrDefault(a => a.SongID == editedSong.SongID);
            if (editingSong != null)
            {
                editingSong.NameOfSong = editedSong.NameOfSong;
                editingSong.NameOfArtist = editedSong.NameOfArtist;
                editingSong.Duration = editedSong.Duration;
                editingSong.SongURL = editedSong.SongURL;
                editingSong.PictureURL = editedSong.PictureURL;
                editingSong.FunFact = editedSong.FunFact;
                context.SaveChanges();
            }
            
        }

        public string GetURL(int id)
        {
            var specificSong = context.Songs.FirstOrDefault(a => a.SongID == id);

            return specificSong.SongURL;
        }

        public Song GetFunFact(int id)
        {
            var specificSong = context.Songs.FirstOrDefault(a => a.SongID == id);

            return specificSong;
        }
    }
}
