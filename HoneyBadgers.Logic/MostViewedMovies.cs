using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.Logic
{
    public class MostViewedMovies
    {
        public Data Data { get; }

        public MostViewedMovies(Data data)
        {
            Data = data;
        }

        private Dictionary<string, int> MoviesWatched()
        {
            Dictionary<string, int> moviesWatched = new Dictionary<string, int>();

            foreach (var user in Data.Users)
            {
                foreach (var movie in user.UserMovieStatus)
                {
                    if (!moviesWatched.ContainsKey(movie.Key) && movie.Value == "Watched")
                    {
                        moviesWatched.Add(movie.Key, 1);
                    }
                    else if(moviesWatched.ContainsKey(movie.Key) && movie.Value == "Watched")
                    {
                        moviesWatched[movie.Key] += 1;
                    }
                }
            }

            return moviesWatched;
        }

        public void SortMostWatched()
        {
            var moviesWatched = MoviesWatched();

            Console.WriteLine("----------\tRANDOM DATA\t----------\n");

            foreach (var movie in moviesWatched)
            {
                Console.WriteLine($"|{movie.Value}| {movie.Key}");
            }

            Console.WriteLine();

            Console.WriteLine("----------\tMOST VIEWED MOVIES\t----------\n");

            foreach (var movie in moviesWatched.OrderByDescending(key => key.Value))
            {
                if (movie.Value == 1)
                {
                    Console.WriteLine($"|{movie.Value}| user watched {movie.Key}");
                }
                else
                {
                    Console.WriteLine($"|{movie.Value}| users watched {movie.Key}");
                }
            }

            Console.WriteLine();
        }

        public void SortLeastWatched()
        {
            var moviesWatched = MoviesWatched();

            Console.WriteLine("----------\tLEAST VIEWED MOVIES\t----------\n");

            foreach (var movie in moviesWatched.OrderBy(key => key.Value))
            {
                if (movie.Value == 1)
                {
                    Console.WriteLine($"|{movie.Value}| user watched {movie.Key}");
                }
                else
                {
                    Console.WriteLine($"|{movie.Value}| users watched {movie.Key}");
                }
            }

            Console.WriteLine();
        }
    }
}