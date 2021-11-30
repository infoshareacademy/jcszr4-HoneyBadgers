using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories
{
    public interface IFavoriteMoviesRepository
    {
        List<string> GetAll();
        void AddFavorite(string movieId);
        void RemoveFavorite(string movieId);
    }
}