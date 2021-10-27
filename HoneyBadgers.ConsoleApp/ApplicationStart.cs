using System;
using System.Collections.Generic;
using HoneyBadgers.ConsoleApp.Services;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp
{
    public class ApplicationStart
    {
        private IUserRepository _usersRepository;
        private IMovieRepository _movieRepository;

        private readonly string _logo = @"
                                     _   _                               _____           _                     
                                    | | | |                             | ___ \         | |                    
                                    | |_| | ___ _ __ ___ _ _ _____      | |_/ / __ _  __| | __ _  ___ _ __ ___ 
                                    |  _  |/ _ \| '_ \ / _ \ | | |      | ___ \/ _` |/ _` |/ _` |/ _ \ '__/ __|
                                    | | | | (_) | | | |  __/ |_| |      | |_/ / (_| | (_| | (_| |  __/ |  \__ \
                                    \_| |_/\___/|_| |_|\___|\__, |      \____/ \__,_|\__,_|\__, |\___|_|  |___/
                                                             __/ |                          __/ |              
                                                            |___/                          |___/               ";

        public ApplicationStart(IUserRepository usersRepository, IMovieRepository movieRepository)
        {
            _usersRepository = usersRepository;
            _movieRepository = movieRepository;
        }

        public void Start()
        {
            Console.Title = "Honey-Badgers - Simple application to search for movies";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            {
                while (true)
                {
                    string prompt = "\nWelcome to the Honey-Badgers application. What would you like to do? \n(Use the arrows keys to cycle through options and press enter to select an option.)";
                    string[] options = { "Search movie by the name", "Add new user", "Add new movie", "Information", "Exit" };
                    Menu mainMenu = new Menu(_logo + prompt, options);
                    int selectedIndex = mainMenu.Run();
                    switch (selectedIndex)
                    {
                        case 0:
                            RunSearchMenu();
                            break;
                        case 1:
                            RunAddUserMenu();
                            break;
                        case 2:
                            RunAddMovieMenu();
                            break;
                        case 3:
                            DisplayInformation();
                            break;
                        case 4:
                            QuitApp();
                            break;
                    }
                }
            }
        }
        private void QuitApp()
        {
            Environment.Exit(0);
        }

        private void DisplayInformation()
        {
            Console.Clear();
            Console.WriteLine("This application have been created by Honey-Badgers team.");
            Console.WriteLine("It simply allows you to search for movies by their name, rating or even by the most frequent assignments to users.");
            Console.WriteLine("You can also put a movie in the list of movies you want to see in the future.");
            Console.WriteLine("Finally, you are able to check if you have already watched the movie!");
            Console.WriteLine("Have fun!:)\n");
            Console.WriteLine("Credits goes to: Beata Giełbaga, Patryk Wiśniewski, Sebastian Leszczyński and Maciej Tomala");
            Console.WriteLine("\nPress any key to return to the main menu.");

            Console.ReadKey(true);
            RunMainMenu();
        }

        private void RunSearchMenu()
        {
            Console.Clear();
            Console.WriteLine("What movie are you looking for?\n(click ESC button if u wish to return to the main menu)\n");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
                {
                    var input = Console.ReadLine();
                    var outData = Searcher.FindByName(_movieRepository.Movies, input);
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Key.Title}, {item.Value}");
                    }
                    Console.WriteLine("\nPress ESC if u wish to return to the main menu or continue to search by typing another text \n");
                }
            }
        }
        private void SearchTitle(IEnumerable<Movie> movies)
        {
            Console.Clear();
            Console.WriteLine("What movie are you looking for?\n(click ESC button if u wish to return to the main menu)");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
                {
                    var input = Console.ReadLine();
                    var findedMovies = Searcher.FindByName(movies, input);
                    foreach (var movie in findedMovies)
                    {
                        Console.WriteLine($"{movie.Key.Title}");
                    }
                    Console.WriteLine("\nPress ESC if u wish to return to the main menu or continue to search by typing another text");
                }
            }

        }

        private void RunAddUserMenu()
        {
            Console.Clear();
            var userService = new UserRepository();
            userService.AddUser();

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
            RunMainMenu();
        }
        private void RunAddMovieMenu()
        {
            Console.Clear();
            var movieRepository = new MovieRepository();
            //movieService.AddMovie();
            //TODO: POPRAWIC
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
            RunMainMenu();
        }
    }
}
