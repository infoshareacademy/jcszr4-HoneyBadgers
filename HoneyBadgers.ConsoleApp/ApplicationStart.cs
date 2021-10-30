using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HoneyBadgers.ConsoleApp.Services;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp
{
    public class ApplicationStart
    {
        private IUserRepository _usersRepository;
        private IMovieRepository _movieRepository;

        private readonly string _logo = @" _   _                               _____           _                     
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
                    string prompt = _logo + "\nWelcome to the Honey-Badgers application. What would you like to do? \n(Use the arrows keys to cycle through options and press enter to select an option.)";
                    string[] options = { "Search movie by the name", 
                                        "Add new user", 
                                        "Add new movie", 
                                        "Information", 
                                        "Exit" };
                    Menu mainMenu = new Menu(prompt, options);
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
        }

        private void RunSearchMenu()
        {
            Console.Clear();
            string prompt = _logo + "\nHow you want to search?";
            string[] options = { "Search by title",
                                "Search by rating lower than",
                                "Search by rating higher than",
                                "Search by rating between lower and higher",
                                "Back to Main menu"};
            Menu menu = new Menu(prompt, options);
            var selectedItem = menu.Run();
            switch (selectedItem)
            {
                case 0:
                    RunSearchByTitle();
                    break;
                case 1:
                    RunSearchByRatingLowerThan();
                    break;
                case 2:
                    RunSearchByRatingHigherThan();
                    break;
                case 3:
                    RunSearchByRatingBetweenLowerAndHigher();
                    break;
                case 4:

                    break;
            }
            
        }
        private void RunAddUserMenu()
        {
            Console.Clear();
            var userService = new UserRepository();
            userService.AddUser();

            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
        }
        private void RunAddMovieMenu()
        {
            Console.Clear();
            var movieRepository = new MovieRepository();
            //movieService.AddMovie();TODO: POPRAWIC
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
        }

        private void RunSearchByTitle()
        {
            Console.WriteLine("What movie are you looking for?\n(click ESC button if u wish to return to the main menu)\n");
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                {
                    var input = Console.ReadLine();
                    var outData = Searcher.FindByName(_movieRepository.Movies, input);
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Key.Title}, {item.Value}");
                    }
                    Console.WriteLine("\nPress ENTER if u wish to return to the main menu\n");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter) return;

                }
            }
        }

        private void RunSearchByRatingLowerThan()
        {
            Console.WriteLine("Type highest ImdbRating movie u want to see" +
                                "\n(click ESC button if u wish to return to the main menu)\n");
            Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                string input = Console.ReadLine();
                input.Replace('.', ',');
                if (double.TryParse(input, out double highestRating))
                {
                    var outData = Searcher.FindMovieWithRatingLowerThan(_movieRepository.Movies, highestRating);
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Title} || {item.ImdbRating}");
                    }
                    Console.WriteLine("\nPress ENTER if u wish to return to the main menu\n");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter) return;
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }

        private void RunSearchByRatingHigherThan()
        {
            Console.WriteLine("Type lowest ImdbRating movie u want to see\n" +
                                "(click ESC button if u wish to return to the main menu)\n");
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                {
                    var input = Console.ReadLine();
                    double lowerRating = 0.0;
                    while (true)
                    {
                        if (Double.TryParse(input, out lowerRating)) break;
                        Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");
                        input = Console.ReadLine();
                    }

                    var outData = Searcher.FindMovieWithRatingHigherThan(_movieRepository.Movies, lowerRating);
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Title} || {item.ImdbRating}");
                    }
                    Console.WriteLine("\nPress ENTER if u wish to return to the main menu\n");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter) return;
                }
            }
        }
        private void RunSearchByRatingBetweenLowerAndHigher()
        {
            Console.WriteLine("Type lower Rating movie u want to see" +
                                "\n(click ESC button if u wish to return to the main menu)\n");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                {
                    var input = Console.ReadLine();
                    double lowerRating = 0.0;
                    while (true)
                    {
                        //, CultureInfo.InvariantCulture
                        if (Double.TryParse(input,out lowerRating)) break;
                        Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");
                        input = Console.ReadLine();
                    }
                    Console.WriteLine("Type lower Rating movie u want to see");
                    input = Console.ReadLine();
                    double higherRating = 0.0;
                    while (true)
                    {
                        if (Double.TryParse(input, out higherRating)) break;
                        Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");
                        input = Console.ReadLine();
                    }
                    var outData = Searcher.FindMovieWithRatingBetweenLowerHigher(_movieRepository.Movies, lowerRating, higherRating);
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Title} || {item.ImdbRating}");
                    }
                    Console.WriteLine("\nPress ENTER if u wish to return to the main menu\n");
                    if (Console.ReadKey(true).Key == ConsoleKey.Enter) return;
                }
            }
        }
    }
}
