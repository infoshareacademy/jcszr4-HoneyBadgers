using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Repositories.Interfaces;
using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.Logic.Services
{
    public class FavoriteMoviesService : IFavoriteMoviesService
    {
        private IMovieService _movieService { get; }
        private IFavoriteMoviesRepository _favoriteMovies { get; set; }
        public FavoriteMoviesService(IFavoriteMoviesRepository favoriteMovies, IMovieService movieService)
        {
            _favoriteMovies = favoriteMovies;
            _movieService = movieService;
        }

        public List<string> GetAllFavoriteMovieId()
        {
            return _favoriteMovies.GetAll();
        }

        public void AddFavorite(string id)
        {
            if (_favoriteMovies.GetAll().Any(m => m == id)) { return; }
            _favoriteMovies.AddFavorite(id);
        }
        public void RemoveFavorite(string id)
        {
            _favoriteMovies.RemoveFavorite(id);
        }

    }
}
