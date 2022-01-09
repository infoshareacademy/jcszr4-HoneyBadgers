using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Repositories;
using System.Collections.Generic;
using System.Linq;


namespace HoneyBadgers.Logic.Services
{
    public static class SearchService
    {
        public static Dictionary<Movie, int> FindByName(string searchInput)
        {
            searchInput = searchInput.Trim();
            var inputParts = searchInput.Split(" ");

            var results = new Dictionary<Movie, int>();
            foreach (var movie in MovieRepository.Movies)
            {
                var movieTitle = movie.Title.ToLower();
                var precision = 0;
                foreach (var partInput in inputParts)
                {
                    if (movieTitle.Contains(partInput.ToLower()))
                    {
                        precision += 1;
                    }
                }

                if (precision > 0)
                {

                    results.Add(movie, precision);
                }
            }

            results.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return results;
        }

        public static List<Movie> FindMovieWithRatingBetweenLowerHigher(List<Movie> movies, double lowestRating, double highestRating)
        {
            return movies.Where(movie => movie.ImdbRating >= lowestRating && movie.ImdbRating <= highestRating)
                .OrderByDescending(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<MovieViewModel> FindMovieWithRatingBetweenLowerHigher(List<MovieViewModel> movies, double lowestRating, double highestRating)
        {
            return movies.Where(movie => movie.ImdbRating >= lowestRating && movie.ImdbRating <= highestRating)
                .OrderByDescending(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<Movie> FindMovieWithRatingLowerThan(IEnumerable<Movie> movies, double highestRating)
        {
            return movies.Where(movie => movie.ImdbRating <= highestRating)
                .OrderByDescending(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<MovieViewModel> FindMovieWithRatingLowerThan(IEnumerable<MovieViewModel> movies, double highestRating)
        {
            return movies.Where(movie => movie.ImdbRating <= highestRating)
                .OrderByDescending(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<Movie> FindMovieWithRatingHigherThan(IEnumerable<Movie> movies, double lowestRating)
        {
            return movies.Where(movie => movie.ImdbRating >= lowestRating)
                .OrderBy(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<MovieViewModel> FindMovieWithRatingHigherThan(IEnumerable<MovieViewModel> movies, double lowestRating)
        {
            return movies.Where(movie => movie.ImdbRating >= lowestRating)
                .OrderBy(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<Movie> SortMoviesByRatingFromHighest(IEnumerable<Movie> movies)
        {
            return movies.OrderByDescending(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<MovieViewModel> SortMoviesByRatingFromHighest(IEnumerable<MovieViewModel> movies)
        {
            return movies.OrderByDescending(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<Movie> SortMoviesByRatingFromLowest(IEnumerable<Movie> movies)
        {
            return movies.OrderBy(movie => movie.ImdbRating)
                .ToList();
        }
        public static List<MovieViewModel> SortMoviesByRatingFromLowest(IEnumerable<MovieViewModel> movies)
        {
            return movies.OrderBy(movie => movie.ImdbRating)
                .ToList();
        }
    }
}