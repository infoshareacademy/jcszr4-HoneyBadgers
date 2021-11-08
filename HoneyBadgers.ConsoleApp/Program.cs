using System;
using HoneyBadgers.Logic;
using HoneyBadgers.Logic.Repositories;

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
