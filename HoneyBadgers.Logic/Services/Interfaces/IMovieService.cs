using HoneyBadgers.Logic.Enums;
using System.Collections.Generic;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IMovieService
    {
        List<Movie> GetAll();
        Movie GetById(string id);
        List<Movie> GetSortMovie(List<Movie> moviesToSort, SortType sortType);
    }
}
