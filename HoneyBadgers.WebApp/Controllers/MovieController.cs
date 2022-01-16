 feature/favmovies
﻿using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Models;

﻿using System.Linq;
using HoneyBadgers.Logic.Enums;
 master
using HoneyBadgers.Logic.Services;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var movie = _movieService.GetById(id);
            var favouriteMoviesId = _favoriteMoviesService.GetAllFavoriteMovieId();
            var model = Map(movie);
            model.IsFavorite = favouriteMoviesId.Contains(model.Id);
            return View(model);

        }

        private MovieViewModel Map(Movie movie)
        {
            return new MovieViewModel()
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
                Title = movie.Title
            };
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

        public IActionResult AddFavotire(string id)
        {
            _favoriteMoviesService.AddFavorite(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveFavotire(string id)
        {
            _favoriteMoviesService.RemoveFavorite(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
