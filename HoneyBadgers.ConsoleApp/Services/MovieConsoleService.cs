using HoneyBadgers.ConsoleApp.Helpers;
using HoneyBadgers.Logic;
using HoneyBadgers.Logic.HoneyBadgers.Logic.Repositories.Interfaces;
using System;
using System.Linq;

namespace HoneyBadgers.ConsoleApp.Services
{
    class MovieConsoleService
    {
        private IMovieRepository _movieRepository;
        public MovieConsoleService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public Movie AddMovie()
        {
            Console.WriteLine("Adding new movie\n");
            var movie = GetNewMovieData();
            Console.WriteLine("The movie has been added correctly");
            return movie;
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
            movie.ImdbID = Guid.NewGuid().ToString("N");

            return movie;
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

        public void PrintMovies()
        {
            Console.WriteLine("LIST OF MOVIES:");
            foreach (var movie in _movieRepository.Movies)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    $"TITLE: {movie.Title} || RELEASE YEAR: {movie.Year}");
                Console.WriteLine("");
                Console.ResetColor();
            }
        }
        public Movie EditMovieData()
        {
            Console.WriteLine("Enter title of the movie you wish to edit");
            var selectedTitle = "";
            while (true)
            {
                var titleInput = Console.ReadLine();
                if (_movieRepository.Movies.Any(m => m.Title.Equals(titleInput, StringComparison.OrdinalIgnoreCase)))
                {
                    selectedTitle = titleInput;
                    break;
                }
                Console.WriteLine("There is no such movie");
            }
            var selectedMovie = _movieRepository.Movies.FirstOrDefault(mov => mov.Title.Equals(selectedTitle, StringComparison.OrdinalIgnoreCase));

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
            Console.WriteLine($"Current plot is: {selectedMovie.Plot}. \nType new plot or press enter to continue without changes");
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

            return selectedMovie;
        }
    }
}
