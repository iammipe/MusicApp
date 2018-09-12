using Microsoft.AspNetCore.Mvc;
using mnRelations.Models;
using mnRelations.ModelView;
using mnRelations.Services;
using System.Collections.Generic;

namespace mnRelations.Controllers
{
    public class PlaylistController : Controller
    {
        IPlaylist _services;
        ISongs _servicesSongs;

        public PlaylistController(IPlaylist _services, ISongs _servicesSongs)
        {
            this._services = _services;
            this._servicesSongs = _servicesSongs;
        }

        /*      CREATE                       */
        /* ----------------
         * AddPlaylistViewModel playlist
         * ----------------- */
        public void Add( AddPlaylistViewModel addingPlaylist )
        {
            _services.Add(addingPlaylist);
            return;
        }

        /*      READ                         */
        /* --------------------------------- */
        public IActionResult Index(int id)
        {
            
            ModelViewPlaylist vm = new ModelViewPlaylist
            {
                Playlist = _services.Read(id),
                Songs = _servicesSongs.ReadAll()
            };

            return View(vm);
        }

        /*      UPDATE                       */
        /* --------------------------------- */
        public void RenamePlaylist( RenamePlaylistViewModel renamingPlaylist )
        {
            _services.Rename(renamingPlaylist);
        }

        /*      DELETE                       */
        /* --------------------------------- */
        public void DeletePlaylist( string playlistName )
        {
            _services.Delete(playlistName);
            return;
        }

        public void DeleteSongFromPlaylist( DeleteSongFromPlaylistViewModel deletingSongFromPlaylist )
        {
            _services.DeleteSongFromPlaylist(deletingSongFromPlaylist);
        }


        public void AddSongsToPlaylist(AddingSongsToPlaylistViewModel fullDataAddingSongsToPlaylist)
        {
            _services.AddSongsToPlaylist(fullDataAddingSongsToPlaylist);
            return;
        }
    }
}
