using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace HoneyBadgers.Logic
{
    public class Data
    {
        public List<User> Users = new();
        public List<Movie> Movies = new();

        public Data()
        {
            
        }

        public void LoadData(string userFilePath, string movieFilePath)
        {
            LoadUsers(userFilePath);
            LoadMovies(movieFilePath);
            InitMockData();
        }
        public void LoadUsers(string fileName)
        {
            var path = Directory.GetCurrentDirectory() + "/Resources/" + fileName;
            using var file = new StreamReader(path);
            try
            {
                var json = file.ReadToEnd();
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var users = JsonConvert.DeserializeObject<List<User>>(json, serializerSettings);
                if (users != null && users.Count > 0)
                {
                    Users = users;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Problem reading users.json file");
            }
        }

        public void LoadMovies(string fileName)
        {
            var path = Directory.GetCurrentDirectory() + "/Resources/" + fileName;
            using var file = new StreamReader(path);
            try
            {
                var json = file.ReadToEnd();
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                var moviesDto = JsonConvert.DeserializeObject<List<MovieDto>>(json, serializerSettings);
                if (moviesDto != null && moviesDto.Count > 0)
                {
                    Movies = moviesDto.Select(MapMovie).ToList();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Problem reading movies.json file");
            }
        }

        private Movie MapMovie(MovieDto movieDto)
        {
            return new Movie
            {
                Title = movieDto.Title,
                Year = movieDto.Year,
                Director = movieDto.Director,
                Writer = movieDto.Writer,
                Actors = movieDto.Actors.Split(",").ToList(),
                Plot = movieDto.Plot,
                Genre = movieDto.Genre.Split(",").ToList(),
                Country = movieDto.Country,
                Status = MovieStatus.NoStatus,
                Rating = null,
                Ratings = movieDto.Ratings
            };
        }

        private void InitMockData()
        {
            var random = new Random();
            foreach (var user in Users)
            {
                var movie = Movies[random.Next(0, 6)];
                if (movie != null)
                {
                    movie.Status = MovieStatus.Watched;
                    movie.Rating = random.Next(1, 5);
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
                var rate = (double)sumRates / rates.Count();
                movie.Ratings.Add(new Rating("User votes", rate.ToString()));
            }
           
        }
    }
}
