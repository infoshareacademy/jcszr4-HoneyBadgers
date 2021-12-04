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
            var model = _favoriteMoviesService.GetAllMoviesAsMovieViewModels();
            return View(model);
        }
        public IActionResult ShowMovies(FilterTypeEnum filterType)
        {
            
            var model = _favoriteMoviesService.GetAllMoviesAsMovieViewModels();
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
