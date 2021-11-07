using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("The movie has been added correctly");
        }

        private Movie GetNewMovieData()
        {
            var movie = new Movie();
            Console.WriteLine("Enter title:");
            movie.Title = StringValidation(2, 30);

            Console.WriteLine("\nEnter year:");
            var movieYear = YearValidation();

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
        public void PrintMovies()
        {
            Console.WriteLine("LIST OF MOVIES:");
            foreach (var movie in Movies)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"TITLE:{movie.Title} RELEASE YEAR: {movie.Year}");
                Console.WriteLine("");
                Console.ResetColor();
            }
        }
        private Movie EditMovieData()
        {
            Console.WriteLine("Enter title of the movie you wish to edit");
            var selectedTitle = "";
            while (true)
            {
                var titleInput = Console.ReadLine();
                if (Movies.Any(m => m.Title.Equals(titleInput, StringComparison.OrdinalIgnoreCase)))
                {
                    selectedTitle = titleInput;
                    break;
                }
                Console.WriteLine("There is no such movie");
            }
            var selectedMovie = Movies.FirstOrDefault(mov => mov.Title.Equals(selectedTitle, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"Current movie title is: {selectedMovie.Title}. Type new title or press enter to continue without changes");
            var title = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(title.Trim()))
            {
                selectedMovie.Title = title;
            }

            Console.WriteLine($"Current movie year of release is: {selectedMovie.Year}. Type new year");
            selectedMovie.Year = YearValidation();
            

            Console.WriteLine($"Current director is: {selectedMovie.Director}. Type director or press enter to continue without changes");
            var director = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(director.Trim()))
            {
                selectedMovie.Director = director;
            }
            Console.WriteLine($"Current writer is: {selectedMovie.Writer}. Type writer or press enter to continue without changes");
            var writer = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(writer.Trim()))
            {
                selectedMovie.Writer = writer;
            }
            Console.WriteLine($"Current actors are: {selectedMovie.Actors}. Type new actors or press enter to continue without changes");
            var actors = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(actors.Trim()))
            {
                selectedMovie.Actors = actors;
            }
            Console.WriteLine($"Current plot is: {selectedMovie.Plot}. Type new plot or press enter to continue without changes");
            var plot = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(plot.Trim()))
            {
                selectedMovie.Plot = plot;
            }
            Console.WriteLine($"Current genre is: {selectedMovie.Genre}. Type new genre or press enter to continue without changes");
            var genre = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(genre.Trim()))
            {
                selectedMovie.Genre = genre;
            }
            Console.WriteLine($"Current country is: {selectedMovie.Country}. Type new country or press enter to continue without changes");
            var country = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(country.Trim()))
            {
                selectedMovie.Country = country;
            }
            Console.WriteLine($"Current rating is: {selectedMovie.ImdbRating}. Type new rating or press enter to continue without changes");
            do
            {
                var ratingInput = Console.ReadLine();
                double rating;
                bool wasparsedSuccessfully = double.TryParse(ratingInput, out rating);
                if (wasparsedSuccessfully == false)
                {
                    Console.WriteLine("Something went wrong! \nYou have not entered a numeric value.");
                    break;
                }
                if (rating > 10 && rating < 0)
                {
                    Console.WriteLine("Rating value must be between 0-10");
                }
                selectedMovie.ImdbRating = rating;
                
            } while (true);

            return selectedMovie;
        }
        public void MovieDataEdition()
        {
            Console.WriteLine("Would you like to edit any movie data?");
            Console.WriteLine("Press ENTER to print the list of users or any key to continue without...");

            ConsoleKey choice = Console.ReadKey(true).Key;
            if (choice == ConsoleKey.Enter) { PrintMovies(); }
            var editedMovie = EditMovieData();
            Console.Clear();
            Console.WriteLine($"Changes are saved for movie: {editedMovie.Title}");

        }
    }
}
