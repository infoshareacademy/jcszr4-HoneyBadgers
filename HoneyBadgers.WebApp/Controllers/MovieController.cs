using HoneyBadgers.Logic;
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
        public List<Movie> Movies { get; private set; } = new List<Movie>();
        public List<User> Users { get; private set; } = new List<User>();
        public MovieController()
        {
            if ((Movies != null) && (!Movies.Any()))
            {
                Movies.AddRange(FileDataReader.LoadMovies());
            }
            if ((Users != null) && (!Users.Any()))
            {
                Users.AddRange(FileDataReader.LoadUsers());
            }
            MockMovieData();
        }
        public IActionResult Index()
        {
            var model = Movies;
            return View(model);
        }
        public IActionResult ShowMovies(FilterTypeEnum filterType)
        {
            var model = Movies;
            switch (filterType)
            {
                case FilterTypeEnum.ByMostPopular:
                    model = Movies.OrderByDescending(m => m.ViewsNumber).ToList();
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
            foreach (var user in Users)
            {
                user.Movies = new List<Movie>();
                foreach (var movie in Movies)
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
