using System;
using System.Collections.Generic;
using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Helpers;

namespace HoneyBadgers.ConsoleApp.Repositories
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
            movie.Title = StringValidation(2, 30);

            Console.WriteLine("\nEnter year:");
            movie.Year = YearValidation();

            Console.WriteLine("\nEnter director:");
            movie.Director = StringValidation(2, 30);

            Console.WriteLine("\nEnter writer:");
            movie.Writer = StringValidation(2, 30);

            Console.WriteLine("\nEnter actors, you can add several after comma:");
            movie.Actors = StringValidation(2, 30);

            Console.WriteLine("\nEnter plot:");
            movie.Plot = StringValidation(2, 30);

            Console.WriteLine("\nEnter genre, you can add several after comma:");
            movie.Genre = StringValidation(2, 30);

            Console.WriteLine("\nEnter country");
            movie.Country = StringValidation(2, 30);

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

        private string StringValidation(int minLength, int maxLength)
        {
            var valid = false;
            string input = "";
            while (!valid)
            {
                input = Console.ReadLine();
                valid = Validators.StringValidator(input, minLength, maxLength);
                if (!valid)
                {
                    Console.WriteLine("The given value is incorrect. The provided value should be a word from 2 to 30 characters.");
                }
            }

            return input;
        }
    }
}
