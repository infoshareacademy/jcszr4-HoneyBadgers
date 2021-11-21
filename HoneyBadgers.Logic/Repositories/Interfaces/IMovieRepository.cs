using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories
{
    public interface IMovieRepository
    {
        static List<Movie> Movies { get; }
        List<Movie> GetAll();
        void AddMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}