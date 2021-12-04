using System;
using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        void AddMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}