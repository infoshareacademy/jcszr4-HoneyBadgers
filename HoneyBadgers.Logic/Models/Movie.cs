using System.Collections.Generic;

namespace HoneyBadgers.Logic.Models
{
    
    public class Movie
    {
        public string ImdbID { get; set; } //TODO: ZAIMPLEMENTOWAĆ
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public double ImdbRating { get; set; }
        public List<Rating> Ratings { get; set; }

    }
}
