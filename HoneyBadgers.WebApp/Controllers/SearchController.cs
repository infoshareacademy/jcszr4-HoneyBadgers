using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Logic.Dto;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private static string _searchInput;

        public SearchController(IMovieService movieService, IUserService userService)
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

            model = _movieService.GetAllMovieShortModel().Result.Where(x => x.Title.ToLower().Contains(search.ToLower())).ToList();

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
