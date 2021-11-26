using HoneyBadgers.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic.Services
{
    public class MockDataService : IMockDataService
    {
        private IMovieService _movieService;
        private IUserService _userService;
        public MockDataService(IMovieService movieService, IUserService userService)
        {
            _movieService = movieService;
            _userService = userService;
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
                        movie.ViewsNumber++;
                    }
                }
            }
        }
    }
}
