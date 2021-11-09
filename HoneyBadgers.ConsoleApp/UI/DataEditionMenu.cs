using System;
using HoneyBadgers.ConsoleApp.Services;
using HoneyBadgers.Logic.Repositories;

namespace HoneyBadgers.ConsoleApp.UI
{
    class DataEditionMenu
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _usersRepository;

        public DataEditionMenu(IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            _usersRepository = userRepository;
        }

        public void RunEditionMenu()
        {
            Console.Clear();
            string prompt = "Which data would you like to edit?";
            string[] options =
            {
                "Edit user data",
                "Edit movie data",
                "Back to Main menu"
            };
            Menu menu = new Menu(prompt, options);
            var selectedItem = menu.Run();
            switch (selectedItem)
            {
                case 0:
                    RunUserDataEdition();
                    break;
                case 1:
                    RunMovieDataEdition();
                    break;
                case 2:
                    break;
            }
        }
        private void RunUserDataEdition()
        {
            var _userConsoleService = new UserConsoleService(_usersRepository);
            Console.Clear();
            Console.WriteLine("Would you like to edit any user data?");
            Console.WriteLine("Press ENTER to print the list of users or any key to continue without...");

            ConsoleKey choice = Console.ReadKey(true).Key;
            if (choice == ConsoleKey.Enter) { _userConsoleService.PrintUsers(); }
            var user = _userConsoleService.EditUserData();
            _usersRepository.EditUser(user);

            Console.WriteLine("Changes saved successfully");
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
        }

        private void RunMovieDataEdition()
        {
            var _movieConsoleService = new MovieConsoleService(_movieRepository);
            Console.Clear();
            Console.WriteLine("Would you like to edit any movie data?");
            Console.WriteLine("Press ENTER to print the list of movies or any key to continue without...");

            ConsoleKey choice = Console.ReadKey(true).Key;
            if (choice == ConsoleKey.Enter) { _movieConsoleService.PrintMovies(); }
            var editedMovie = _movieConsoleService.EditMovieData();
            _movieRepository.EditMovie(editedMovie);
            Console.Clear();
            Console.WriteLine($"Changes are saved for movie: {editedMovie.Title}");
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
        }
    }
}