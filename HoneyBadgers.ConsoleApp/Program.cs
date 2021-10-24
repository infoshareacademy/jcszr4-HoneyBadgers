using System;
using HoneyBadgers.ConsoleApp.Services;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();
            var movieRepository = new MovieRepository();

            ApplicationStart ourApplicationStart = new ApplicationStart(userRepository, movieRepository);
            ourApplicationStart.Start();
        }
    }
}
