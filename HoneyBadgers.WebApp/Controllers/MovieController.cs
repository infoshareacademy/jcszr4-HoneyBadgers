using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Services;
using HoneyBadgers.WebApp.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private MovieService _movieService;
        private UserService _userService;
        public MovieController()
        {
            _movieService = new MovieService();
            _userService = new UserService();

            MockMovieData();
        }
        public IActionResult Index()
        {
            List<Movie> model = _movieService.GetAll();
            return View(model);
        }
        public IActionResult ShowMovies(FilterTypeEnum filterType, bool sortDescending)
        {
            var model = _movieService.GetAll();
            switch (filterType)
            {
                case FilterTypeEnum.ByMostPopular:
                    model = model.OrderByDescending(m => m.ViewsNumber).ToList();
                    break;
                default:
                    break;
            }
            return PartialView("_MoviePartialView", model);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

        private void MockMovieData()
        {
            var movies = _movieService.GetAll();
            var users = _userService.GetAll();
            foreach (var user in users)
            {
                user.Movies = new List<Movie>();
                foreach (var movie in movies)
                {
                    var movieStatus = new Random().Next(0, Enum.GetNames(typeof(MovieStatus)).Length);
                    if (movieStatus == (int)MovieStatus.Watched)
                    {
                        user.Movies.Add(movie);
                        movie.ViewsNumber++;
                    }
                }
            }
        }
    }
}
