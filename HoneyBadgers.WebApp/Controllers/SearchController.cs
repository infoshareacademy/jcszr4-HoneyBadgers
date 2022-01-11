using HoneyBadgers.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string search)
        {
            var model = new Search();
            model.Query = search;
            return View(model);
        }
    }
}
