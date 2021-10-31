using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp
{
    class SearchConsoleMenu
    {
        private readonly IMovieRepository _movieRepository;
        public SearchConsoleMenu(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        internal void RunSearchMenu()
        {
            Console.Clear();
            string prompt = "How you want to search?";
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

        private void RunSearchByTitle()
        {
            while (true)
            {
                Console.WriteLine("What movie are you looking for?\n" +
                                  "(click ESC button if u wish to return to the main menu)\n");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                {
                    var input = Console.ReadLine();
                    var outData = Searcher.FindByName(_movieRepository.Movies, input);
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Key.Title}, {item.Value}");
                    }
                    Console.WriteLine("\nPress ESC if u wish to return to the main menu\nPress any other key to try again...");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;

                }
            }
        }

        private void RunSearchByRatingLowerThan()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Type highest ImdbRating movie u want to see" +
                                "\n(click ESC button if u wish to return to the main menu)\n");
                Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");
            
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                string input = Console.ReadLine();
                input = input.Replace('.', ',');
                if (double.TryParse(input, out double highestRating))
                {
                    var outData = Searcher.FindMovieWithRatingLowerThan(_movieRepository.Movies, highestRating);
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Title} || {item.ImdbRating}");
                    }
                    Console.WriteLine("\nPress ESC if u wish to return to the main menu\nPress any other key to try again...");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;
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
                    input = input.Replace('.', ',');
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
                    input = input.Replace('.', ',');
                    double lowerRating = 0.0;
                    while (true)
                    {
                        if (Double.TryParse(input, out lowerRating)) break;
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
