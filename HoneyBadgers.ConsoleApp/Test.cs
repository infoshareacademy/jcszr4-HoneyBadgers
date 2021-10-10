using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp
{
    public class Test
    {
        private readonly Data _data;

        public Test(Data data)
        {
            _data = data;
        }

        internal void Run()
        {
            
            while (true)
            {
                var input = Console.ReadLine();
                var outData = Searcher.FindByName(_data, input);
                foreach (var item in outData)
                {
                    Console.WriteLine($"{item.Key.Title}, {item.Value}");
                }
            }
        }

    }
}
