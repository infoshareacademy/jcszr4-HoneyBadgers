using HoneyBadgers.Logic.Enums;
using System.Collections.Generic;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie GetById(string id);
        List<Movie> GetSortMovie(List<Movie> sortedMovies, SortType sortType);
        List<MovieViewModel> GetSortMovie(List<MovieViewModel> sortedMovies, SortType sortType);
    }
}
