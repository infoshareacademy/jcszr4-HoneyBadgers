using System;
using System.Collections.Generic;
using System.Linq;


namespace HoneyBadgers.Logic
{
    public static class Searcher
    {
        public static Dictionary<Movie,int> FindByName(List<Movie> movies, string searchInput)
        {
            //TODO: Jak się pozbyć Dictionary?! :o 
            var inputParts = searchInput.Split(" "); 
            var results = new Dictionary<Movie, int>();
            foreach (var itemDB in movies)
            {
                var movieTitle = itemDb.Title.ToLower();
                var precision = 0;
                foreach (var partInput in inputParts)
                {
                    if (movieTitle.Contains(partInput.ToLower()))
                    {
                        precision += 1;
                    }
                }
                
                if (precision > 0)
                {
                    
                    results.Add(itemDb,precision);
                }
            }

            results.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return results;
        }
    }
}