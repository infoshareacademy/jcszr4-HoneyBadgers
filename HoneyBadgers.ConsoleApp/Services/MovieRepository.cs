using System;
using System.Collections.Generic;

namespace HoneyBadgers.Logic
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> Movies { get; private set; } = new List<Movie>();

        public MovieRepository()
        {
            Movies.AddRange(FileDataReader.LoadMovies());
        }

        public void AddMovie()
        {
            Console.WriteLine("Adding new movie\n");
            var movie = GetNewMovieData();
            Movies.Add(movie);

            Console.WriteLine("The video has been added correctly");
        }

        private Movie GetNewMovieData()
        {
            var movie = new Movie();
            Console.WriteLine("Enter title:");
            movie.Title = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter year:");
            movie.Year = YearValidation();

            Console.WriteLine("\nEnter director");
            movie.Director = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter writer:");
            movie.Writer = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter actors:");
            movie.Actors = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter plot:");
            movie.Plot = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter genre");
            movie.Genre = Console.ReadLine() ?? "";

            Console.WriteLine("\nEnter country");
            movie.Country = Console.ReadLine() ?? "";

            return movie;
        }

        private int YearValidation()
        {
            var valid = false;
            var input = 0;
            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out input) && input > 1900;
                if (!valid)
                {
                    Console.WriteLine("The given value is incorrect. The value provided should be a positive number greater then 1900. Try again:");
                }
            }
            return input;
        }
    }
}
