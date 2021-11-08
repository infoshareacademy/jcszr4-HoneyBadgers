using System.Collections.Generic;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> Movies { get; }
        void AddMovie(Movie movie);
        void RemoveMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}