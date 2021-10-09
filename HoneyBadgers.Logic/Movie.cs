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
        Watched,
        WantToWatch,
        NoStatus
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
            
        }

        public Movie AddMovie()
        {
            Movie movie = new Movie("title", 2021, "director", "writer", new List<string>(), "plot", new List<string>(), "country");
            Type type = movie.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(movie, null));
            }

            return movie;
        }
    }
}
