using System;
using System.Collections.Generic;
using System.Linq;


namespace HoneyBadgers.Logic
{
    public static class Searcher
    {
        public static Dictionary<Movie,int> FindByName(List<Movie> movies, string searchInput)
        {
            //TODO: Jak się pozbyć Dictionary?! :o 
            var inputParts = searchInput.Split(" "); 
            var results = new Dictionary<Movie, int>();
            foreach (var movie in movies)
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
                    
                    results.Add(movie,precision);
                }
            }

            results.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return results;
        }

        public static List<Movie> FindMovieWithRatingBetweenLowerHigher(List<Movie> movies, double lowestRating, double highestRating)
        {
            return movies.Where(movie => movie.Rating >= lowestRating && movie.Rating <= highestRating).ToList();
        }

        public static List<Movie> FindMovieWithRatingLowerThan(List<Movie> movies,double highestRating)
        {
            return movies.Where(movie => movie.Rating <= highestRating).ToList();
        }
        public static List<Movie> FindMovieWithRatingHigherThan(List<Movie> movies, double lowestRating)
        {
            return movies.Where(movie => movie.Rating >= lowestRating).ToList();
        }
        public static List<Movie> SortMoviesByRatingFromHighest(List<Movie> movies)
        {
            return movies.OrderByDescending(movie => movie.Rating).ToList();
        }
        public static List<Movie> SortMoviesByRatingFromLowest(List<Movie> movies)
        {
            return movies.OrderBy(movie => movie.Rating).ToList();
        }
    }
}