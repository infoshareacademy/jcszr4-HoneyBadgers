using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.Logic
{
    public enum MovieStatus
    {
        NoStatus,
        Watched,
        WantToWatch
        
    }
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public MovieStatus Status { get; set; }
        public double? Rating { get; set; }
        public List<Rating> Ratings { get; set; }

    }
}
