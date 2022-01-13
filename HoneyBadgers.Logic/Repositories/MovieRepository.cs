using HoneyBadgers.Logic.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Logic.Helpers;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public static List<Movie> Movies { get; set; } = new List<Movie>();
        
        public MovieRepository()
        {
            if (!Movies.Any())
            {
                var movies = FileDataReader.LoadMovies();
                foreach (var movie in movies)
                {
                    movie.Id = Guid.NewGuid().ToString();
                }
                Movies.AddRange(movies);
            }
        }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }
        public void EditMovie(Movie movie)
        {
            var index = Movies.FindIndex(m => m.Id == movie.Id);
            Movies[index] = movie;
        }
    }
}
