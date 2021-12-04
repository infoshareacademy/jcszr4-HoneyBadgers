using System.Collections.Generic;
using HoneyBadgers.Logic.Repositories;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IFavoriteMoviesService
    {
        List<string> GetAll();
        void AddFavorite(string id);
        void RemoveFavorite(string id);
    }
}