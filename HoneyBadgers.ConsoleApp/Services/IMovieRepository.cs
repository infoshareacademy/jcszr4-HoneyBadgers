using System.Collections.Generic;

namespace HoneyBadgers.Logic
{
    public interface IMovieRepository
    {
        List<Movie> Movies { get; }
        void AddMovie(Movie movie);
        void RemoveMovie(Movie movie);
        void EditMovie(Movie movie);
    }
}