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
            Console.WriteLine("Adding new movie\n\n");
            var movie = GetNewMovieData();
            Movies.Add(movie);

            Console.WriteLine("The video has been added correctly");
        }

        private Movie GetNewMovieData()
        {
            var type = typeof(MovieDto);
            var properties = type.GetProperties();
            var movie = new MovieDto();
            foreach (var property in properties)
            {
                if (property.Name is "ImdbRating" or "Ratings")
                {
                    continue;
                }
                Console.WriteLine($"Enter {property.Name.ToLower()}");
                if (property.Name == "Year")
                {
                    var intValue = YearValidation();
                    property.SetValue(movie, intValue);
                }
                else
                {
                    var input = Console.ReadLine();
                    property.SetValue(movie, input ?? "");
                }
            }
            Console.WriteLine();
            return new Movie(movie);
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
