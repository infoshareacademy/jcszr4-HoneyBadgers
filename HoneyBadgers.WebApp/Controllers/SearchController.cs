using HoneyBadgers.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    public class SearchController : BaseController
    {
        public IActionResult Index(string search)
        {
            var model = new SearchModel();
            model.Query = search;
            return View(model);
        }
    }
}
