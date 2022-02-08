using System;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IRepository<Movie> _movieRepository;

        public SearchController(IRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index(string search)
        {
            List<Movie> model;

            if (search == null)
            {
                model = _movieRepository
                    .GetAll()
                    .ToList();
                return View(model);
            }

            model = _movieRepository
                .GetAll()
                .Where(movie => movie.Title.ToLower().Contains(search))
                .ToList();
            return View(model);
        }
    }
}
