using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Services;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService, IMockDataService mockDataService)
        {
            _movieService = movieService;
            mockDataService.MockMovieData();
        }
        public IActionResult Index()
        {
            List<Movie> model = _movieService.GetAll();
            return View(model);
        }
        public IActionResult ShowMovies(FilterTypeEnum filterType)
        {
            var model = _movieService.GetSortMovie(filterType);
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
