using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        public List<string> Actors { get; set; }
        public string Plot { get; set; }
        public List<string> Genre { get; set; }
        public string Country { get; set; }
        public MovieStatus Status { get; set; }
        public double? Rating { get; set; }
        public List<Rating> Ratings { get; set; }

        public Movie()
        {
            
        }

        public Movie(string title, int year, string director, string writer, List<string> actors, string plot, List<string> genre, string country)
        {
            Title = title;
            Year = year;
            Director = director;
            Writer = writer;
            Actors = actors;
            Plot = plot;
            Genre = genre;
            Country = country;
        }
    }
}
