using System.Collections.Generic;

namespace HoneyBadgers.Logic.Repositories
{
    public interface IMovieRepository
    {
        static List<Movie> Movies { get; }
        void AddMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}