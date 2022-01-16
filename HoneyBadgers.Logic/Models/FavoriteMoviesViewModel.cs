using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic.Models
{
    public class FavoriteMoviesViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public double ImdbRating { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        public int ViewsNumber { get; set; }
        public bool IsFavorite { get; set; }
    }
}
