using System.Collections.Generic;

namespace HoneyBadgers.Logic
{
    public static class Searcher
    {
        public static List<Movie> FindByName(List<Movie> db, string searchInput)
        {
            var partsSearchName = searchInput.Split(" "); 
            var results = new List<Movie>();
            foreach (var itemDB in db)
            {
                var partsMovieTitle = itemDB.Title.Split(" ");
                var searchMatched = 0;
                foreach (var partMovieTitle in partsMovieTitle)
                {
                    foreach (var partSearchName in partsSearchName)
                    {
                        if (partMovieTitle.Contains(partSearchName))
                        {
                            searchMatched += 1;
                            break;
                        }
                    }
                }
                if (searchMatched > 0)
                {
                    results.Add(itemDB);
                }
            }
            return results;
        }
    }
}
