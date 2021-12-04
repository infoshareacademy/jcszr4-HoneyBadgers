using System.Collections.Generic;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Repositories;

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