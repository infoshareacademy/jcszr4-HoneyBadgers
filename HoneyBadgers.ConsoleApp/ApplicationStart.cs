using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HoneyBadgers.Logic
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

            string[] options = {"Continue as guest", "Information", "Exit"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    ContinueAsGuest();
                    break;
                case 1:
                    DisplayInformation();
                    break;
                case 2:
                    QuitApp();
                    break;
            }
        }

        private void QuitApp()
        {
            WriteLine("\nPress any key to exit");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void DisplayInformation()
        {
            Clear();
            WriteLine("This application have been created by Honey-Badgers team.");
            WriteLine("It simply allows you to search for movies by their name, rating or even by the most frequent assignments to users.");
            WriteLine("You can also put a movie in the list of movies you want to see in the future.");
            WriteLine("Finally, you are able to check if you have already watched the movie!");
            WriteLine("Have fun!:)");
            WriteLine("\nPress any key to return to the main menu.");
            ReadKey(true);
            RunMainMenu();
        }
        private void ContinueAsGuest()
        {

        }
    }
}
