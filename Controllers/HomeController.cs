using Microsoft.AspNetCore.Mvc;
using mnRelations.ModelView;
using mnRelations.Services;

namespace mnRelations.Controllers
{
    public class HomeController : Controller
    {
        IMusic _services;

        public HomeController(IMusic _services)
        {
            this._services = _services;
        }

        public IActionResult Index()
        {
            return View(_services.Get());
        }
    }
}
