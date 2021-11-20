using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.Logic.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> Movies { get; private set; } = new List<Movie>();
        
        public MovieRepository()
        {
            Movies.AddRange(FileDataReader.LoadMovies());
        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }
        public void EditMovie(Movie movie)
        {
            var index = Movies.FindIndex(m => m.ImdbID == movie.ImdbID);
            Movies[index] = movie;
        }
    }
}
