using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic.Helpers;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Repositories;

namespace HoneyBadgers.ConsoleApp.ConsoleControl
{
    class MovieMenu
    {
        private readonly IMovieRepository _movieRepository;

        public MovieMenu(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }

        internal void RunMovieMenu()
        {
            Console.Clear();
            string prompt = "How you want to do?";
            string[] options = { "Add movie",
                "Edit movie",
                "View all movie",
                "Back to Main menu"};
            Menu menu = new Menu(prompt, options);
            var selectedItem = menu.Run();
            switch (selectedItem)
            {
                case 0:
                    RunAddMovie();
                    break;
                case 1:
                    RunEditMovie();
                    break;
                case 2:
                    RunViewAllMovie();
                    break;
                case 3:
                    
                    break;
            }
        }

        private void RunViewAllMovie()
        {
            throw new NotImplementedException();
        }

        private void RunEditMovie()
        {
            throw new NotImplementedException();
        }

        private void RunAddMovie()
        {
            var movie = new Movie();
            var minLength = 2;
            var maxLength = 30;
            var minimalYear = 1900;
            string input;
            Console.Clear();
            do
            {
                Console.WriteLine("Enter movie title:");
                Console.WriteLine($"Type title length between {minLength}-{maxLength} character.");
                input = Console.ReadLine();
                if (Validators.StringValidator(input, minLength, maxLength))
                {
                    movie.Title = input;
                    break;
                }
                Console.WriteLine("Wrong input!");
                WrongInputLength(input);
            } while (true);

            Console.Clear();
            do
            {
                Console.WriteLine("Enter movie release YEAR:");
                Console.WriteLine($"Type year AFTER {minimalYear}.");
                input = Console.ReadLine();
                var verify = Int32.TryParse(input,out int inputYear);
                if (verify && Validators.YearValidation(inputYear, minimalYear))
                {
                    movie.Year = inputYear;
                    break;
                }
                Console.WriteLine("Wrong input!");
                if (!verify) Console.WriteLine("Type numerical value like 1940, 2005 or 2020");
                if(!Validators.YearValidation(inputYear,minimalYear)) Console.WriteLine("Type value bigger then 1900!");
            } while (true);

            Console.Clear();
            do
            {
                Console.WriteLine("Enter director name:");
                Console.WriteLine($"Type name between {minLength}-{maxLength} character.");
                input = Console.ReadLine();
                if (Validators.StringValidator(input, minLength, maxLength))
                {
                    movie.Director = input;
                    break;
                }
                Console.WriteLine("Wrong input!");
                WrongInputLength(input);
            } while (true);

            Console.Clear();
            do
            {
                Console.WriteLine("Enter writer name:");
                Console.WriteLine($"Type name between {minLength}-{maxLength} character.");
                input = Console.ReadLine();
                if (Validators.StringValidator(input, minLength, maxLength))
                {
                    movie.Director = input;
                    break;
                }
                Console.WriteLine("Wrong input!");
                WrongInputLength(input);
            } while (true);

            do
            {
                Console.WriteLine("Enter actors name, you can add several after comma:");
                Console.WriteLine($"Type name between {minLength}-{maxLength} character.");
                input = Console.ReadLine();
                if (Validators.StringValidator(input, minLength, maxLength))
                {
                    movie.Actors = input;
                    break;
                }
                Console.WriteLine("Wrong input!");
                WrongInputLength(input);
            } while (true);

            do
            {
                Console.WriteLine("Enter movie plot:");
                Console.WriteLine($"Type name between {minLength}-300 character.");
                input = Console.ReadLine();
                if (Validators.StringValidator(input, minLength, 300))
                {
                    movie.Plot = input;
                    break;
                }
                Console.WriteLine("Wrong input!");
                switch (input.Length)
                {
                    case < 2:
                        Console.WriteLine($"Input is too short, you type {input.Length} character");
                        break;
                    case > 300:
                        Console.WriteLine($"Input is too long, you type {input.Length} character");
                        break;
                }
            } while (true);

            Console.WriteLine("\nEnter plot:");
            movie.Plot = StringValidation(2, 30);

            Console.WriteLine("\nEnter genre, you can add several after comma:");
            movie.Genre = StringValidation(2, 30);

            Console.WriteLine("\nEnter country");
            movie.Country = Validators.StringValidator(Console.ReadLine(),2, 30);
        }

        private static void WrongInputLength(string input)
        {
            switch (input.Length)
            {
                case < 2:
                    Console.WriteLine($"Input is too short, you type {input.Length} character");
                    break;
                case > 30:
                    Console.WriteLine($"Input is too long, you type {input.Length} character");
                    break;
            }
        }
    }
}
