using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HoneyBadgers.Logic.Services;

namespace HoneyBadgers.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IFavoriteMoviesService _favoriteMoviesService;
        public MovieController(IMovieService movieService, IMockDataService mockDataService, IFavoriteMoviesService favoriteMoviesService)
        {
            _movieService = movieService;
            _favoriteMoviesService = favoriteMoviesService;
        }
        public IActionResult Index()
        {
            var model = _favoriteMoviesService.GetAllMoviesAsMovieViewModels();
            return View(model);
        }

        public IActionResult ShowMovies(SortType sortType, double ratingFrom, double ratingTo)
        {
            
            var model = _favoriteMoviesService.GetAllMoviesAsMovieViewModels();
            var movies = this._movieService.GetAll();

            if (ratingTo == 0)
            {
                ratingTo = 10;
            }

            movies = SearchService.FindMovieWithRatingBetweenLowerHigher(movies, ratingFrom, ratingTo);
            movies = _movieService.GetSortMovie(movies, sortType);
            var favoriteMovies = _favoriteMoviesService.GetAll();
            var toDisplay = new List<MovieViewModel>();
			foreach (var movie in movies)
			{
                var movieToDisplay = new MovieViewModel
                {
                    Actors = movie.Actors,
                    Country = movie.Country,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    Id = movie.Id,
                    ImdbRating = movie.ImdbRating,
                    Plot = movie.Plot,
                    Poster = movie.Poster,
                    Ratings = movie.Ratings,
                    Writer = movie.Writer,
                    ViewsNumber = movie.ViewsNumber,
                    Year = movie.Year,
                    Title = movie.Title,
                    IsFavorite = favoriteMovies.Find(f => f == movie.Id) != null
                };
                toDisplay.Add(movieToDisplay);
            }
            var model = toDisplay;
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
