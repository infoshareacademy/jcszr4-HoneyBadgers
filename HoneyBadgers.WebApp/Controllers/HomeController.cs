using HoneyBadgers.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HoneyBadgers.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieService _movieService;
        private readonly UserService _userService;
        private readonly IReviewService _reviewService;

        public HomeController(ILogger<HomeController> logger,
            IMovieService movieService,
            UserService userService,
            IReviewService reviewService)
        {
            _logger = logger;
            _movieService = movieService;
            _userService = userService;
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            var modal = new HomeViewModel()
            {
                RecentMovies = await _movieService.GetRecent(),
                FavoriteMovies = _userService.GetFavoriteMovies(),
                RecentReviews = await _reviewService.GetRecentReviews()
            };
            return View(modal);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
