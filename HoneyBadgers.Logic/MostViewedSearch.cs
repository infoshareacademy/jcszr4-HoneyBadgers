using System;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.Logic
{
    public class MostViewedSearch
    {
        public Data Data { get; }

        public MostViewedSearch(Data data)
        {
            Data = data;
        }

        private Dictionary<string, int> MostViewed()
        {
            Dictionary<string, int> movieStatusDictionary = new Dictionary<string, int>();

            foreach (var user in Data.Users)
            {
                foreach (var movie in user.UserMovieStatus)
                {
                    Console.WriteLine($"{movie.Key} | {movie.Value}");

                    if (!movieStatusDictionary.ContainsKey(movie.Key) && movie.Value == "Watched")
                    {
                        movieStatusDictionary.Add(movie.Key, 1);
                    }
                    else if(movieStatusDictionary.ContainsKey(movie.Key) && movie.Value == "Watched")
                    {
                        movieStatusDictionary[movie.Key] += 1;
                    }
                }
            }

            return movieStatusDictionary;
        }

        public void SortMostViewed()
        {
            var mostViewed = MostViewed();
            List<int> movies;

            
        }
    }
}