using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic
{
    public class MovieDto
    {
        public string Title;
        public int Year;
        public string Director;
        public string Writer;
        public string Actors;
        public string Plot;
        public string Genre;
        public string Country;
        public double imdbRating;
        public List<Rating> Ratings;
    }
}
