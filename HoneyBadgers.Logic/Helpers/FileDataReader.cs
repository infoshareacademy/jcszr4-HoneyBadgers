using System;
using System.Collections.Generic;
using System.IO;
using HoneyBadgers.Logic.Models;
using Newtonsoft.Json;

namespace HoneyBadgers.Logic.Helpers
{
    public static class FileDataReader
    {
        private const string UsersFilePath = "Resources/users.json";

        private const string MoviesFilePath = "Resources/movies.json";


        public static List<User> LoadUsers()
        {
            return LoadData<User>(UsersFilePath);
        }

        public static List<Movie> LoadMovies()
        {
            return LoadData<Movie>(MoviesFilePath);
        }

        private static List<T> LoadData<T>(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath)) throw new FileNotFoundException(nameof(filePath));

            try
            {
                var fileText = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(fileText);
            }
            catch (Exception e)
            {
                throw new Exception($"An error has occurred while reading Users records. Ex: {e.Message}");
            }
        }

        // private void InitMockData()
        // {
        //     var random = new Random();
        //     foreach (var user in users)
        //     {
        //         var movie = movies[random.Next(0, users.Count)];
        //         if (movie != null)
        //         {
        //             movie.Status = MovieStatus.Watched;
        //             movie.Rating = random.Next(1, 10);
        //             user.Movies = new List<Movie> { movie };
        //         }
        //     }
        // }
        //
        // private void RatingMovie(Movie movie)
        // {
        //     var rates = new List<double>();
        //     foreach (var user in users)
        //     {
        //         var userMovie = user.Movies.FirstOrDefault(m => m.Title.Equals(movie.Title, StringComparison.OrdinalIgnoreCase));
        //         if (userMovie != null && userMovie.Rating != null)
        //         {
        //             rates.Add((double)userMovie.Rating);
        //         }
        //     }
        //
        //     if (rates.Count > 0)
        //     {
        //         var sumRates = rates.Sum();
        //         var rate = sumRates / rates.Count;
        //         movie.Ratings.Add(new Rating("User votes", rate.ToString()));
        //     }
        //    
        // }
    }
}
