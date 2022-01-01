using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Services;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HoneyBadgers.WebApp.Db;

namespace HoneyBadgers.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IFavoriteMoviesService _favoriteMoviesService;
        private MoviesContext _moviesContext;
        public MovieController(IMovieService movieService, IMockDataService mockDataService, IFavoriteMoviesService favoriteMoviesService, MoviesContext moviesContext)
        {
            _movieService = movieService;
            _favoriteMoviesService = favoriteMoviesService;
            //mockDataService - żeby się wywołał konstruktor
            _moviesContext = moviesContext;


        }
        public IActionResult Index()
        {
            var model = _favoriteMoviesService.GetAllMoviesAsMovieViewModels();
            return View(model);
        }

        public IActionResult ShowMovies(SortType sortType, double ratingFrom, double ratingTo, bool isFavorite)
        {

            var movies = _favoriteMoviesService.GetAllMoviesAsMovieViewModels();

            if (ratingTo == 0)
            {
                ratingTo = 10;
            }

            movies = SearchService.FindMovieWithRatingBetweenLowerHigher(movies, ratingFrom, ratingTo);
            if (isFavorite)
            {
                movies = movies.Where(m => m.IsFavorite).ToList();
            }
            var model = _movieService.GetSortMovie(movies, sortType);

            return PartialView("_MoviePartialView", model);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(string id)
        {
            var model = _movieService.GetById(id);
            return View(model);
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
