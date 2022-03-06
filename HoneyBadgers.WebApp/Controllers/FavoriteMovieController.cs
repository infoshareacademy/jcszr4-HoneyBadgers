using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers.Logic.Services;
using HoneyBadgers.Logic.Services.Interfaces;

namespace HoneyBadgers.WebApp.Controllers
{
    public class FavoriteMovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly UserService _userService;
        

        public FavoriteMovieController(IMovieService movieService, UserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }
        // GET: FavoriteMovieController
        public async Task<ActionResult> Index()
        {
            var movies = await _movieService.GetAllMovieShortModel();
            var model = movies.Where(e => e.IsFavorite);
            return View(model);
        }
    }
}
