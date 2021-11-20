using HoneyBadgers.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace HoneyBadgers.WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        public List<Movie> Movies { get; private set; } = new List<Movie>();
        public BaseController()
        {
            Movies.AddRange(FileDataReader.LoadMovies());
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewData["movies"] = Movies;
            base.OnActionExecuting(filterContext);
        }
    }
}
