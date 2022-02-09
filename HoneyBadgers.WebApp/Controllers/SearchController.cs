using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Dto;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly UserService _userService;

        public SearchController(IMovieService movieService, UserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(string search)
        {
            var model = await _movieService.GetAllMovieShortModel();

            if (search == null)
            {
                return View(model);
            }

            model = model
                .Where(movie => movie.Title.ToLower().Contains(search))
                .ToList();

            if (model.Count == 0)
            {
                return View();
            }

            return View(model);
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
    }
}
