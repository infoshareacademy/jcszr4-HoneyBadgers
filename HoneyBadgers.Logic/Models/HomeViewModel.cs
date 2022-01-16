using System.Collections.Generic;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.Logic.Models
{
    public class HomeViewModel
    {
        public List<Movie> RecentMovies { get; set; }
        public List<Movie> FavoriteMovies { get; set; }
    }
}
