using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Helpers;
using System;
using System.Linq;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.ConsoleApp.ConsoleControl
{
    class WszystkoCoTrzebaZostawićWConsoli
    {

        private Movie GetNewMovieData()
        {
            
            return movie;
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

        public void MovieDataEdition()
        {
            Console.WriteLine("Would you like to edit any movie data?");
            Console.WriteLine("Press ENTER to print the list of movies or any key to continue without...");

            ConsoleKey choice = Console.ReadKey(true).Key;
            if (choice == ConsoleKey.Enter) { GetAllMovies(); }
            var editedMovie = EditMovieData();
            Console.Clear();
            Console.WriteLine($"Changes are saved for movie: {editedMovie.Title}");
        }





    }
}
