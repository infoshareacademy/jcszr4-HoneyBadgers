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
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly UserService _userService;
        private static string _searchInput;

        public SearchController(IMovieService movieService, UserService userService)
        {
            _movieService = movieService;
            _userService = userService;
        }

        public IActionResult Index(string search)
        {
            _searchInput = search;
            List<MovieDto> model;

            if (search == null)
            {
                model = _movieService.GetAllMovieShortModel().Result.ToList();
                return View(model);
            }

            model = _movieService.GetAllMovieShortModel().Result.Where(x => x.Title.ToLower().Contains(search)).ToList();

            return model.Count == 0 ? View() : View(model);
        }
        public IActionResult AddFavorite(string id)
        {
            _userService.AddFavoriteMovie(id);
            return RedirectToAction("Index", new { search = _searchInput });
        }

        public IActionResult RemoveFavorite(string id)
        {
            _userService.RemoveFavoriteMovie(id);
            return RedirectToAction("Index", new { search = _searchInput });
        }
    }
}
