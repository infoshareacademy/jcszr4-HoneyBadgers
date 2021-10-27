using System;
using System.Collections.Generic;
using System.Linq;


namespace HoneyBadgers.Logic
{
    public static class Searcher
    {
        public static Dictionary<Movie,int> FindByName(string searchInput)
        {
            var inputParts = searchInput.Split(" "); 
            var results = new Dictionary<Movie, int>();
            foreach (var itemDB in Data.Movies)
            {
                var movieTitle = itemDB.Title.ToLower();
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
                    
                    results.Add(itemDB,precision);
                }
            }

            results.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return results;
        }
    }
}