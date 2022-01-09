using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Services
{
    public class MockDataService : IMockDataService
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly IFavoriteMoviesService _favoriteMoviesService;
        public MockDataService(IMovieService movieService, IUserService userService, IFavoriteMoviesService favoriteMoviesService)
        {
            _movieService = movieService;
            _userService = userService;
            _favoriteMoviesService = favoriteMoviesService;
            MockMovieData();
        }
        public void MockMovieData()
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
                        movie.ViewsNumber = new Random().Next(1000,999999);
                    }

                    var dice = new Random().NextDouble() * 6;
                    if (dice > 5.5)
                    {
                        _favoriteMoviesService.AddFavorite(movie.Id);
                    }
                }
            }

        }
    }
}
