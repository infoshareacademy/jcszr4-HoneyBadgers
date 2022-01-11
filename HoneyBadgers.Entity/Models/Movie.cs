using System;
using System.Collections.Generic;

namespace HoneyBadgers.Entity.Models
{
    public class Movie: BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public DateTime Released { get; set; }
        public string Runtime { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public virtual List<Genre> Genre { get; set; }
        public string Country { get; set; }
        public double ImdbRating { get; set; }
        public string Poster { get; set; }
        public string Language { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public int ViewsNumber { get; set; }
        public virtual List<FavoriteMovie> FavoriteMovies { get; set; }
    }
}
