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
