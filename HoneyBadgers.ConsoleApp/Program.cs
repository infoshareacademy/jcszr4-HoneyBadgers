using System;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new Data();
            var isDataLoaded = data.LoadData();

            if (isDataLoaded)
            {
                ApplicationStart ourApplicationStart = new ApplicationStart();
                ourApplicationStart.Start();
            }
        }
    }
}
