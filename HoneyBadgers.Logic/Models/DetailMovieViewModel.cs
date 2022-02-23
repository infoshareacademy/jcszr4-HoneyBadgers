using System.Collections.Generic;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.Logic.Models
{
    public class DetailMovieViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Runtime { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public List<Genre> Genre { get; set; }
        public string Country { get; set; }
        public double ImdbRating { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        public int ViewsNumber { get; set; }
        public string Language { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public bool IsFavorite { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
