using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.ConsoleApp.Services;
using HoneyBadgers.Logic;
using static System.Console;

namespace HoneyBadgers.ConsoleApp
{
    public class ApplicationStart
    {
        public void Start()
        {
            Title = "Honey-Badgers - Simple application to search for movies";
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            {
                string prompt = @"
 _   _                              ______           _                     
| | | |                             | ___ \         | |                    
| |_| | ___  _ __   ___ _   _ ______| |_/ / __ _  __| | __ _  ___ _ __ ___ 
|  _  |/ _ \| '_ \ / _ \ | | |______| ___ \/ _` |/ _` |/ _` |/ _ \ '__/ __|
| | | | (_) | | | |  __/ |_| |      | |_/ / (_| | (_| | (_| |  __/ |  \__ \
\_| |_/\___/|_| |_|\___|\__, |      \____/ \__,_|\__,_|\__, |\___|_|  |___/
                         __/ |                          __/ |              
                        |___/                          |___/               
Welcome to the Honey-Badgers application. What would you like to do?
(Use the arrows keys to cycle through options and press enter to select an option.)";
                string[] options = {"Search movie by the name", "Add new user", "Add new movie", "Information", "Exit"};
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        SearchByTheName();
                        RunMainMenu();
                        break;
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        AddMovie();
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
        private void QuitApp()
        {
            Environment.Exit(0);
        }

        private void DisplayInformation()
        {
            Clear();
            WriteLine("This application have been created by Honey-Badgers team.");
            WriteLine(
                "It simply allows you to search for movies by their name, rating or even by the most frequent assignments to users.");
            WriteLine("You can also put a movie in the list of movies you want to see in the future.");
            WriteLine("Finally, you are able to check if you have already watched the movie!");
            WriteLine("Have fun!:)\n");
            WriteLine("Credits goes to: Beata Giełbaga, Patryk Wiśniewski, Sebastian Leszczyński and Maciej Tomala");
            WriteLine("\nPress any key to return to the main menu.");
            
            ReadKey(true);
            RunMainMenu();
        }

        private void SearchByTheName()
        {
            Clear();
            WriteLine("What movie are you looking for?\n(click ESC button if u wish to return to the main menu)\n");
            while (true)
            {
                if (ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
                {
                    var input = ReadLine();
                    var outData = Searcher.FindByName(input);
                    foreach (var item in outData)
                    {
                        WriteLine($"{item.Key.Title}, {item.Value}");
                    }
                    WriteLine("\nPress ESC if u wish to return to the main menu or continue to search by typing another text \n");
                }
            }
        }

        private void AddUser()
        {
            Clear();
            var userService = new UserService();
            userService.AddUser();

            WriteLine("\nPress any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }
        private void AddMovie()
        {
            Clear();
            var movieService = new MovieService();
            movieService.AddMovie();

            WriteLine("\nPress any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }
    }
}
