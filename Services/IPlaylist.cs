using mnRelations.Models;
using mnRelations.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mnRelations.Services
{
    public interface IPlaylist
    {
        void Add(AddPlaylistViewModel playlist); // CREATE PLAYLIST
        Playlist Read(int id); // READ PLAYLIST
        void Rename(RenamePlaylistViewModel renamingPlaylist); // UPDATE PLAYLIST
        void Delete(string playlistName); // DELETE PLAYLIST

        void AddSongsToPlaylist(AddingSongsToPlaylistViewModel fullDataAddingSongsToPlaylist);
        void DeleteSongFromPlaylist(DeleteSongFromPlaylistViewModel deletingSongFromPlaylist);
    }
}
