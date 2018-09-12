using mnRelations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mnRelations.Models;
using mnRelations.ModelView;
using mnRelations.Data;
using Microsoft.EntityFrameworkCore;

namespace mnRelations.DataSql
{
    public class SqlPlaylistsData : IPlaylist
    {
        private MusicDBContext _context;

        public SqlPlaylistsData(MusicDBContext context)
        {
            _context = context;
        }

        public void Add(AddPlaylistViewModel playlist)
        {
            Playlist newPlaylist = new Playlist
            {
                PlaylistName = playlist.NameOfPlaylist,
                PlaylistImage = playlist.UrlOfPlaylist
            };

            if (newPlaylist.PlaylistName == null)
                newPlaylist.PlaylistName = "Unknown name";

            if( newPlaylist.PlaylistImage == null)
                newPlaylist.PlaylistImage = "https://i.stack.imgur.com/uRD9M.jpg";
            else if (newPlaylist.PlaylistImage.Contains(".png") || newPlaylist.PlaylistImage.Contains(".jpg") || newPlaylist.PlaylistImage.Contains(".jpeg"))
                newPlaylist.PlaylistImage = playlist.UrlOfPlaylist;
            else
                newPlaylist.PlaylistImage = "https://i.stack.imgur.com/uRD9M.jpg";

            _context.Playlists.Add(newPlaylist);
            _context.SaveChanges();
            return;
        }

        public void Delete(string playlistName)
        {
            var toRemovePlaylist = _context.Playlists.FirstOrDefault(e => e.PlaylistName == playlistName);
            if (toRemovePlaylist != null)
            {
                _context.Playlists.Remove(toRemovePlaylist);
                _context.SaveChanges();
            }
        }

        public Playlist Read(int id)
        { 
            return (
                _context.Playlists
                        .Include(x => x.SongPlaylists)
                        .FirstOrDefault(e=> e.PlaylistID == id)
            );
        }

        public void Rename(RenamePlaylistViewModel renamingPlaylist)
        {
            _context.Playlists.FirstOrDefault(e => e.PlaylistName == renamingPlaylist.OldNamePlaylist).PlaylistName = renamingPlaylist.NewNamePlaylist;
            _context.SaveChanges();
            return;
        }

        public void AddSongsToPlaylist(AddingSongsToPlaylistViewModel fullDataAddingSongsToPlaylist)
        {
            Playlist specificPlaylist = _context.Playlists.FirstOrDefault(e => e.PlaylistID == fullDataAddingSongsToPlaylist.PlaylistID);

            foreach (var songIdentificator in fullDataAddingSongsToPlaylist.ArrayOfSongAddingToPlaylist)
            {
                specificPlaylist.SongPlaylists.Add(
                    new SongPlaylist
                    {
                        SongID = songIdentificator
                    }
                );

            }
            _context.SaveChanges();

            return;
        }

        public void DeleteSongFromPlaylist(DeleteSongFromPlaylistViewModel deletingSongFromPlaylist)
        {
            var playlistToUpdate = _context.Playlists.Include(g => g.SongPlaylists).Single(u => u.PlaylistID == deletingSongFromPlaylist.PlaylistID);
            var songToUpdate = _context.Songs.Single(u => u.SongID == deletingSongFromPlaylist.SongID);

            playlistToUpdate.SongPlaylists.Remove(playlistToUpdate.SongPlaylists.Where(ugu => ugu.SongID == songToUpdate.SongID).FirstOrDefault());
            _context.SaveChanges();
        }
    }
}
