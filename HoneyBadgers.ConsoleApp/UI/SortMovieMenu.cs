using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic;

namespace HoneyBadgers.ConsoleApp.UI
{
    class SortMovieMenu
    {
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;

        public SortMovieMenu(IUserRepository userRepository, IMovieRepository movieRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }
        internal void RunSortMenu()
        {
            Console.Clear();
            string promt = "How do you want to search?";
            string[] options =
            {
                "Descending",
                "Ascending"
            };
            Menu menu = new Menu(promt, options);
            var selectItem = menu.Run();
            switch (selectItem)
            {
                case 0:
                    Descending();
                    break;
                case 1:
                    Ascending();
                    break;
            }
        }

        private void Ascending()
        {
            throw new NotImplementedException();
        }

        private void Descending()
        {
            throw new NotImplementedException();
        }
    }
}
