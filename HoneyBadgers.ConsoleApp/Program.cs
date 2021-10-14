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

            ApplicationStart ourApplicationStart = new ApplicationStart();
            ourApplicationStart.Start();
        }
    }
}
