using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services.Interfaces;

namespace HoneyBadgers.WebApp.Controllers
{
    public class FavoriteMovieController : Controller
    {
        
        private readonly IFavoriteMoviesService _favoriteMoviesService;
        private readonly IMovieService _movieService;
        

        public FavoriteMovieController(IMockDataService mockDataService, IFavoriteMoviesService favoriteMoviesService, IMovieService movieService)
        {
            _favoriteMoviesService = favoriteMoviesService;
            _movieService = movieService;
        }
        // GET: FavoriteMovieController
        public ActionResult Index()
        {
            var movies = _favoriteMoviesService.GetAllFavoriteMoviesViewModels();
            var model = movies.Where(e => e.IsFavorite);
            return View(model);
        }
    }
}
