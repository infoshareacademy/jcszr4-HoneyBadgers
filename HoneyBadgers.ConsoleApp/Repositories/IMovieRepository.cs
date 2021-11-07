using System.Collections.Generic;

namespace HoneyBadgers.Logic
{
    public interface IMovieRepository
    {
        List<Movie> Movies { get; }
        void AddMovie();
        void MovieDataEdition();
    }
}