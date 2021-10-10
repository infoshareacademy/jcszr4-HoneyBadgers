using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace HoneyBadgers.Logic
{
    public static class Searcher
    {
        public static Dictionary<Movie,int> FindByName(Data db, string searchInput)
        {
            var inputParts = searchInput.Split(" "); 
            var results = new Dictionary<Movie, int>();
            foreach (var itemDB in db.Movies)
            {
                var movieTitle = itemDB.Title.ToLower();
                var searchMatched = 0; //TODO: Dobrać odpowiednią nazwę!!
                foreach (var partInput in inputParts)
                {
                    if (movieTitle.Contains(partInput.ToLower()))
                    {
                        searchMatched += 1;
                    }
                }
                
                if (searchMatched > 0)
                {
                    
                    results.Add(itemDB,searchMatched);
                } 
            }

            results.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return results;
        }
    }
}