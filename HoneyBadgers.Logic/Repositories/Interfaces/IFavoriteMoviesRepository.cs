using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories.Interfaces
{
    public interface IFavoriteMoviesRepository
    {
        List<string> GetAll();
        void AddFavorite(string movieId);
        void RemoveFavorite(string movieId);
    }
}