using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            var toDisplay = new List<MovieViewModel>();
            var movies = _movieService.GetAll();
            var favorite = _favoriteMoviesService.GetAll();
            foreach (var movie in movies)
            {
                var favoriteMovie = new MovieViewModel();
                favoriteMovie.Actors = movie.Actors;
                favoriteMovie.Country = movie.Country;
                favoriteMovie.Director = movie.Director;
                favoriteMovie.Genre = movie.Genre;
                favoriteMovie.Id = movie.Id;
                favoriteMovie.ImdbRating = movie.ImdbRating;
                favoriteMovie.Plot = movie.Plot;
                favoriteMovie.Poster = movie.Poster;
                favoriteMovie.Ratings = movie.Ratings;
                favoriteMovie.Writer = movie.Writer;
                favoriteMovie.ViewsNumber = movie.ViewsNumber;
                favoriteMovie.Year = movie.Year;
                favoriteMovie.Title = movie.Title;
                favoriteMovie.IsFavorite = favorite.Find(f => f == movie.Id) != null;
                toDisplay.Add(favoriteMovie);
            }
            var model = toDisplay;
            return View(model);
        }
        public IActionResult ShowMovies(FilterTypeEnum filterType)
        {
            var sortedMovies = _movieService.GetSortMovie(filterType);
            var favoriteMovies = _favoriteMoviesService.GetAll();
            var toDisplay = new List<MovieViewModel>();
			foreach (var movie in sortedMovies)
			{
                var movieToDisplay = new MovieViewModel();
                movieToDisplay.Actors = movie.Actors;
                movieToDisplay.Country = movie.Country;
                movieToDisplay.Director = movie.Director;
                movieToDisplay.Genre = movie.Genre;
                movieToDisplay.Id = movie.Id;
                movieToDisplay.ImdbRating = movie.ImdbRating;
                movieToDisplay.Plot = movie.Plot;
                movieToDisplay.Poster = movie.Poster;
                movieToDisplay.Ratings = movie.Ratings;
                movieToDisplay.Writer = movie.Writer;
                movieToDisplay.ViewsNumber = movie.ViewsNumber;
                movieToDisplay.Year = movie.Year;
                movieToDisplay.Title = movie.Title;
                movieToDisplay.IsFavorite = favoriteMovies.Find(f => f == movie.Id) != null;
                toDisplay.Add(movieToDisplay);
            }
            var model = sortedMovies;
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
