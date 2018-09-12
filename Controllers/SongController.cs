using Microsoft.AspNetCore.Mvc;
using mnRelations.Models;
using mnRelations.ModelView;
using mnRelations.Services;
using System;
using System.Collections.Generic;

namespace mnRelations.Controllers
{
    public class SongController : Controller
    {
        ISongs _services;

        public SongController(ISongs _services)
        {
            this._services = _services;
        }


        /*      CREATE                       */
        /* --------------------------------- */
        public IActionResult AddNewSong(Song song)
        {
            _services.Add(song);
            return Redirect("/Song/Index/Id");
        }

        /*      READ                         */
        /* --------------------------------- */
        public IActionResult Index(string id)
        {
            if (id == "Id")
                return View(_services.ReadAll());
            else if (id == "AZ")
                return View(_services.GetAllSongsAZ());

            return NotFound();
        }

        /*      UPDATE                       */
        /* --------------------------------- */
        public Song GetEditingSong(int id)
        {
            return _services.GetSpecificSong(id);
        }

        public void EditingSong(Song submitEditedSong)
        {
            _services.Edit(submitEditedSong);
        }


        /*      DELETE                       */
        /* --------------------------------- */
        public void DeleteSong(int songId)
        {
            _services.Delete(songId);
        }

        /*      VIDEO PLAY                   */
        /* --------------------------------- */
        public string VideoURL(int id)
        {
            return _services.GetURL(id);
        }

        public Song SongDetails (int id)
        {
            return _services.GetSpecificSong(id);

        }
    }
}
