using HoneyBadgers.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(SearchModel search)
        {
            return View(search);
        }
    }
}
