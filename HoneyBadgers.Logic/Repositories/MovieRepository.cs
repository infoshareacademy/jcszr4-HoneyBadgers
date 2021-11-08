using System;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Logic.Models;

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
            if (Movies.Any(m => m.ImdbID == movie.ImdbID)) return;
            Movies.Add(movie);
        }
        public void RemoveMovie(Movie movie)
        {
            foreach (var item in Movies)
            {
                if (item.ImdbID == movie.ImdbID) Movies.Remove(item);
            }
        }
        public void EditMovie(Movie movie)
        {
            foreach (var item in Movies)
            {
                if (item.ImdbID == movie.ImdbID)
                {
                    item.Actors = movie.Actors;
                    item.Country = movie.Country;
                    item.Director = movie.Director;
                    item.Genre = movie.Genre;
                    item.ImdbRating = movie.ImdbRating;
                    item.Plot = movie.Plot;
                    item.Ratings = movie.Ratings;
                    item.Title = movie.Title;
                    item.Writer = movie.Writer;
                    item.Year = movie.Year;
                }
            }
        }
        public List<Movie> GetAllMovies()
        {
            return Movies;
        }

        public string GenerateImdbRating()
        {
            throw new NotImplementedException();
        }
    }
}
