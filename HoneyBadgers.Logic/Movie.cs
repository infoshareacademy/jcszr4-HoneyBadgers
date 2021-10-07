using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic
{
    public enum MovieStatus
    {
        Watched,
        WantToWatch,
        NoStatus
    }
    public class Movie
    {
        public string Title;
        public int Year;
        public string Director;
        public string Writer;
        public List<string> Actors;
        public string Plot;
        public List<string> Genre;
        public string Country;
        public MovieStatus Status;
        public double? Rating;
        public List<Rating> Ratings;

        public Movie()
        {
            
        }
    }
}
