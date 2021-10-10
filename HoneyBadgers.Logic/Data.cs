using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HoneyBadgers.Logic
{
    public class Data
    {
        public List<User> Users { get; set; } = new();
        public List<Movie> Movies { get; set; } = new();

        public void LoadData()
        {
            LoadUsers("Resources/users.json");
            LoadMovies("Resources/movies.json");
            InitMockData();
        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        private void LoadUsers(string fileName)
        {
            try
            {
                var fileText = File.ReadAllText(fileName);
                var users = JsonConvert.DeserializeObject<List<User>>(fileText);
                if (users != null && users.Count > 0)
                {
                    Users = users;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem reading users.json file");
            }
        }

        private void LoadMovies(string fileName)
        {
            try
            {
                var fileText = File.ReadAllText(fileName);
                var movies = JsonConvert.DeserializeObject<List<MovieDto>>(fileText);
                if (movies != null && movies.Count > 0)
                {
                    Movies = movies.Select(m => new Movie(m)).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem reading movies.json file");
            }
        }

        private void InitMockData()
        {
            var random = new Random();
            foreach (var user in Users)
            {
                var movie = Movies[random.Next(0, Movies.Count)];
                if (movie != null)
                {
                    movie.Status = MovieStatus.Watched;
                    movie.Rating = random.Next(1, 10);
                    user.Movies = new List<Movie> { movie };
                }
            }
        }

        private void RatingMovie(Movie movie)
        {
            var rates = new List<int>();
            foreach (var user in Users)
            {
                if (user.Movies.Contains(movie))
                {
                    var userMovie = user.Movies.Find(m => m.Title == movie.Title);
                    if (userMovie != null && userMovie.Rating != null)
                    {
                        rates.Add((int)userMovie.Rating);
                    }

                }
            }

            if (rates.Count > 0)
            {
                var sumRates = rates.Sum();
                var rate = (double)sumRates / rates.Count;
                movie.Ratings.Add(new Rating("User votes", rate.ToString()));
            }
           
        }
    }
}
