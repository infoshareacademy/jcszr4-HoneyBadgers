using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Repositories.Interfaces;

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
                Console.WriteLine("What movie are you looking for?");
                Console.WriteLine("click ESC button if u wish to return to the main menu)");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                {
                    var input = Console.ReadLine();
                    input = input.Trim();
                    var outData = Searcher.FindByName(MovieRepository.Movies, input);
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Key.Title}, {item.Value}");
                    }
                    Console.WriteLine("Press ESC if u wish to return to the main menu");
                    Console.WriteLine("Press any other key to try again...");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;

                }
            }
        }

        private void RunSearchByRatingLowerThan()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Type highest ImdbRating movie u want to see");
                Console.WriteLine("(click ESC button if u wish to return to the main menu)");
                Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
                string input = Console.ReadLine();
                input = input.Replace('.', ',');
                if (double.TryParse(input, out double highestRating))
                {
                    var outData = Searcher.FindMovieWithRatingLowerThan(_movieRepository.Movies, highestRating);
                    if (outData.Count != 0)
                    {
                        foreach (var item in outData)
                        {
                            Console.WriteLine($"{item.Title} || {item.ImdbRating}");
                        }
                        Console.WriteLine("Press ESC if u wish to return to the main menu");
                        Console.WriteLine("Press any other key to try again...");
                        if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;
                    }
                    else
                    {
                        Console.WriteLine("Movies not found, press ENTER to try again");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, press ENTER to try again");
                    Console.ReadLine();
                }
            }
        }

        private void RunSearchByRatingHigherThan()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Type lowest ImdbRating movie u want to see");
                Console.WriteLine("(click ESC button if u wish to return to the main menu)");
                Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");

                if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
            
                var input = Console.ReadLine();
                input = input.Replace('.', ',');


                if (Double.TryParse(input, out double lowerRating))
                {
                    var outData = Searcher.FindMovieWithRatingHigherThan(_movieRepository.Movies, lowerRating);
                    if (outData.Count != 0)
                    {
                        foreach (var item in outData)
                        {
                            Console.WriteLine($"{item.Title} || {item.ImdbRating}");
                        }
                        Console.WriteLine("Press ESC if u wish to return to the main menu");
                        Console.WriteLine("Press any other key to try again...");
                        if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;
                    }
                    else
                    {
                        Console.WriteLine("Movies not found, press ENTER to try again");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input, press ENTER to try again");
                    Console.ReadLine();
                }
            }
        }
        private void RunSearchByRatingBetweenLowerAndHigher()
        {
            while (true)
            {
                string input;
                double lowerRating = 0.0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Type lower ImdbRating movie u want to see");
                    Console.WriteLine("click ESC button if u wish to return to the main menu)");
                    Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");

                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;

                    input = Console.ReadLine();
                    input = input.Trim().Replace('.', ',');
                    if (Double.TryParse(input, out lowerRating))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, press ENTER to try again");
                        Console.ReadLine();
                    }
                } while (true);

                double higherRating = 0.0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Type higher ImdbRating movie u want to see");
                    Console.WriteLine("click ESC button if u wish to return to the main menu)");
                    Console.WriteLine(@"Type rating from 0-10, like 5.3, 2.56 etc. ");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;

                    input = Console.ReadLine();
                    input = input.Trim().Replace('.', ',');
                    if (Double.TryParse(input, out higherRating))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input, press ENTER to try again");
                        Console.ReadLine();
                    }


                } while (true);

                var outData = Searcher.FindMovieWithRatingBetweenLowerHigher(_movieRepository.Movies, lowerRating, higherRating);
                if (outData.Count != 0)
                {
                    foreach (var item in outData)
                    {
                        Console.WriteLine($"{item.Title} || {item.ImdbRating}");
                    }
                    Console.WriteLine("\nPress ESC if u wish to return to the main menu");
                    Console.WriteLine("Press any other key to try again...");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape) return;
                }
                else
                {
                    Console.WriteLine("Movies not found, press ENTER to try again");
                    Console.ReadLine();
                }

            }
        }
    }
}
