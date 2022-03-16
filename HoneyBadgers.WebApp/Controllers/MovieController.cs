using System.Collections.Generic;
using HoneyBadgers.Logic.Enums;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services;
using HoneyBadgers.Logic.Services.Interfaces;
using HoneyBadgers.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly IReportService _reportService;
        private readonly IMovieSortService _movieSortService;
        public MovieController(IMovieService movieService, IUserService userService, IReportService reportService, IMovieSortService movieSortService)
        {
            _movieService = movieService;
            _userService = userService;
            _reportService = reportService;
            _movieSortService = movieSortService;
        }

        public async Task<IActionResult> Index()
        {

            var movies = await _movieService.GetAllMovieShortModel();
            var model = _movieSortService.SortMovie(movies, SortType.ByMostPopularDescending);
            return View(model);
        }

        public async Task<IActionResult> ShowMovies(SortType sortType, double ratingFrom, double ratingTo)
        {
            var movies = await _movieService.GetAllMovieShortModel();

            if (ratingTo == 0)
            {
                ratingTo = 10;
            }

            movies = _movieSortService.FindMovieWithRatingBetweenLowerHigher(movies, ratingFrom, ratingTo);
            var model = _movieSortService.SortMovie(movies, sortType);

            return PartialView("_MoviePartialView", model);
        }

        // GET: MovieController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var model = await _movieService.GetDetailMovie(id);
            foreach (var genre in model.Genre)
            {
                await _reportService.AddGenreStats(new CreateGenreStats()
                {
                    GenreName = genre.Name,
                    GenreId = genre.Id
                });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddReview(CreateReviewViewModel textEditor)
        {
            return View("Index");
        }

        public IActionResult AddFavorite(string id)
        {
            _userService.AddFavoriteMovie(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFavorite(string id)
        {
            _userService.RemoveFavoriteMovie(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddFavoriteInDetail(string id)
        {
            _userService.AddFavoriteMovie(id);
            return RedirectToAction("Details", new { ID = id });
        }

        public IActionResult RemoveFavoriteInDetail(string id)
        {
            _userService.RemoveFavoriteMovie(id);
            return RedirectToAction("Details", new { ID = id });
        }
    }
}
