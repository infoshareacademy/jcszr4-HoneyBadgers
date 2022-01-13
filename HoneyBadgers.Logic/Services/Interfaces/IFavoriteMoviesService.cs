using HoneyBadgers.Logic.Models;
using System.Collections.Generic;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IFavoriteMoviesService
    {
        List<string> GetAllFavoriteMovieId();
        void AddFavorite(string id);
        void RemoveFavorite(string id);
        List<MovieViewModel> GetAllMoviesAsMovieViewModels();
    }
}