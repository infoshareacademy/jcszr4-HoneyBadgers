﻿using HoneyBadgers.ConsoleApp.UI;
using HoneyBadgers.Logic.Repositories;
using System;
using HoneyBadgers.ConsoleApp.ConsoleControl;

namespace HoneyBadgers.ConsoleApp
{
    public class ApplicationStart
    {
        private IUserRepository _usersRepository;
        private IMovieRepository _movieRepository;
        //private SortMovieMenu _sortMovieMenu;

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
            //_sortMovieMenu = new SortMovieMenu(_usersRepository, _movieRepository); //TODO: Czemu dodatkowa lista? A nie sortowanie wszystkiego co mamy w pamięci? 
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
                    string prompt = _logo + "\nWelcome to the Honey-Badgers application. What would you like to do? " +
                                    "\n(Use the arrows keys to cycle through options and press enter to select an option.)";
                    string[] options = { "Search movie by...",
                                        "Search movie by most popular",
                                        "Add new user",
                                        "Add new movie",
                                        "Edit Data",
                                        "Information",
                                        "Exit" };
                    Menu mainMenu = new Menu(prompt, options);
                    int selectedIndex = mainMenu.Run();
                    SearchConsoleMenu searchMenu = new(_movieRepository);
                    SortMovieMenu sortMovieMenu = new (_usersRepository, _movieRepository); //TODO: DLACZEGO PRZYJMUJE REPO Userów? 
                    DataEditionMenu dataEditionMenu = new DataEditionMenu(_usersRepository, _movieRepository); //TODO: DLACZEGO PRZYJMUJE REPO USERÓW? 

                    switch (selectedIndex)
                    {
                        case 0:
                            searchMenu.RunSearchMenu();
                            break;
                        case 1:
                            Console.WriteLine("Available soon!");
                            //_sortMovieMenu.RunSortMenu();
                            break;
                        case 2:
                            RunAddUserMenu();
                            break;
                        case 3:
                            RunAddMovieMenu();
                            break;
                        case 4:
                            dataEditionMenu.RunEditionMenu();
                            break;
                        case 5:
                            DisplayInformation();
                            break;
                        case 6:
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
        private void RunAddUserMenu()
        {
            Console.Clear();
            _usersRepository.AddUser();
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
        }
        private void RunAddMovieMenu()
        {
            Console.Clear();
            _movieRepository.AddMovie();
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey(true);
        }
    }
}
