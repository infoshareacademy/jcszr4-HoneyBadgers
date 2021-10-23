using System;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp
{
    class SearchMenu
    {
        public void SearchTitle()
        {
            var movies = Data.Movies;
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


    }
}
