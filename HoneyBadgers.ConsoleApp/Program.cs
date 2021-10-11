using System;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();
            data.LoadData();

            // ApplicationStart ourApplicationStart = new ApplicationStart();
            // ourApplicationStart.Start();

            foreach (var user in data.Users)
            {
                foreach (var movie in user.UserMovieStatus)
                {
                    Console.WriteLine($"{user.FirstName} | {movie.Key} | {movie.Value}");
                }
            }
        }
    }
}
