using System;
using System.Collections.Generic;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        void AddMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}