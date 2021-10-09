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
            Test t = new(data);
            t.Run();
        }
    }
}
