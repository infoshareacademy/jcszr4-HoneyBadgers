using HoneyBadgers.Logic.Repositories.Interfaces;
using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories
{
    public class FavoriteMoviesRepository : IFavoriteMoviesRepository
    {
        private static List<string> FavoriteMovies { get; set; } = new();

        public List<string> GetAll()
        {
            return FavoriteMovies;
        }
        public void AddFavorite(string movieId)
        {
            FavoriteMovies.Add(movieId);
        }

        public void RemoveFavorite(string movieId)
        {
            FavoriteMovies.Remove(movieId);
        }
    }
}
