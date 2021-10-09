using System.Collections.Generic;

namespace HoneyBadgers.Logic
{
    public static class Searcher
    {
        public static Dictionary<Movie,int> FindByName(List<Movie> db, string searchInput)
        {
            var partsInput = searchInput.Split(" "); 
            var results = new Dictionary<Movie, int>();
            foreach (var itemDB in db)
            {
                var movieTitle = itemDB.Title;
                var searchMatched = 0;
                foreach (var partInput in partsInput)
                {
                    if (movieTitle.Contains(partInput))
                    {
                        searchMatched += 1;
                    }
                }
                
                if (searchMatched > 0)
                {
                    results.Add(itemDB,searchMatched);
                }
            }
            return results;
        }
    }
}
