using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic;

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
            Console.Clear();
            _usersRepository.UserDataEdition();
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
        }

        private void RunMovieDataEdition()
        {
            Console.Clear();
            _movieRepository.MovieDataEdition();
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
        }
    }
}