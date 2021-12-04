using System.Collections.Generic;
using HoneyBadgers.Logic.Repositories;
using System.Linq;
using HoneyBadgers.Logic.Services.Interfaces;

namespace HoneyBadgers.Logic.Services
{
    public class FavoriteMoviesService : IFavoriteMoviesService
    {
        private IFavoriteMoviesRepository _favoriteMovies { get; set; }
        public FavoriteMoviesService(IFavoriteMoviesRepository favoriteMovies)
        {
            _favoriteMovies = favoriteMovies;
        }

        public List<string> GetAll()
        {
            return _favoriteMovies.GetAll();
        }
        public void AddFavorite(string id)
        {
            if(_favoriteMovies.GetAll().Any(m=> m == id)){return;}
            _favoriteMovies.AddFavorite(id);
        }
        public void RemoveFavorite(string id)
        {
                _favoriteMovies.RemoveFavorite(id);
        }

    }
}
