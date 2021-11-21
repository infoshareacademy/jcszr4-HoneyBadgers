using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Repositories;

namespace HoneyBadgers.ConsoleApp.UI
{
    class SortMovieMenu
    {
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly Dictionary<string, int> _userMoviesDictionary;

        public SortMovieMenu(IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;

            foreach (var user in _userRepository.Users)
            {
                user.Movies = new List<Movie>();

                foreach (var movie in _movieRepository.Movies)
                {
                    var movieStatus = new Random().Next(0, Enum.GetNames(typeof(MovieStatus)).Length);
                    if (movieStatus == (int)MovieStatus.Watched)
                    {
                        user.Movies.Add(movie);
                    }
                }
            }
            _userMoviesDictionary = GenerateUserRandomMovies();
        }
        
        internal void RunSortMenu()
        {
            Console.Clear();
            string promt = "How do you want to search?";
            string[] options =
            {
                "Descending",
                "Ascending"
            };
            Menu menu = new Menu(promt, options);
            var selectItem = menu.Run();
            switch (selectItem)
            {
                case 0:
                    Descending();
                    break;
                case 1:
                    Ascending();
                    break;
            }
        }

        private Dictionary<string, int> GenerateUserRandomMovies()
        {
            Dictionary<string, int> moviesDictionary = new Dictionary<string, int>();

            foreach (var movie in _movieRepository.Movies)
            {
                var counter = 0;

                if (!moviesDictionary.ContainsKey(movie.Title))
                {
                    moviesDictionary.Add(movie.Title, 0);
                }

                foreach (var user in _userRepository.Users)
                {
                    if (user.Movies.Contains(movie))
                    {
                        moviesDictionary[movie.Title] = counter++;
                    }
                }
            }

            return moviesDictionary;
        }

        private void Ascending()
        {
            Console.Clear();
            Console.WriteLine("---------MOST POPULAR---------");
            Console.WriteLine("---------  ASCENDING  ---------");
            foreach (var movie in _userMoviesDictionary.OrderBy(key => key.Value))
            {
                Console.WriteLine($"{movie.Value} users watched {movie.Key}");
            }


            Console.ReadKey();
        }

        private void Descending()
        {
            Console.Clear();
            Console.WriteLine("---------MOST POPULAR---------");
            Console.WriteLine("--------- DESCENDING ---------");

            foreach (var movie in _userMoviesDictionary.OrderByDescending(key => key.Value))
            {
                Console.WriteLine($"{movie.Value} users watched {movie.Key}");
            }
            Console.ReadKey();
        }
    }
}
