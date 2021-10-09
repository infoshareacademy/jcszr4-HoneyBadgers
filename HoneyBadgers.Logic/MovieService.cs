using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace HoneyBadgers.Logic
{
    public class MovieService
    {
        public Movie AddMovie()
        {
            var type = typeof(Movie);
            var properties = type.GetProperties();

            var movie = GetMovieFromUser(properties);

            return movie;
        }

        private Movie GetMovieFromUser(IEnumerable<PropertyInfo> properties)
        {
            var movie = new Movie();
            foreach (var property in properties)
            {
                if (property.Name is "Status" or "Rating" or "Ratings")
                {
                    continue;
                }
                Console.WriteLine($"Enter {property.Name.ToLower()}");
                if (property.PropertyType == typeof(string))
                {
                    var input = Console.ReadLine();
                    property.SetValue(movie, input ?? "");
                } else if (property.PropertyType == typeof(List<string>))
                {
                    var list = GetStringList();
                    property.SetValue(movie, list);
                } else if (property.PropertyType == typeof(int))
                {
                    var intValue = IntValidation();
                    property.SetValue(movie, intValue);
                }
            }

            Console.WriteLine();
            return movie;
        }

        private int IntValidation()
        {
            var valid = false;
            var input = 0;
            while (!valid)
            {
                valid = int.TryParse(Console.ReadLine(), out input) && input > 1900;
                if (!valid)
                {
                    Console.WriteLine("The given value is incorrect. The value provided should be a positive number greater then 1900. Try again:");
                }
            }
            return input;
        }

        private List<string> GetStringList()
        {
            Console.WriteLine("Enter next values after comma");
            var input = Console.ReadLine();

            return input != null ? input.Split(',').Select(p => p.Trim()).ToList() : new List<string>();
        }
    }
}
