using System;

namespace HoneyBadgers.WebApp.Models
{
    public class ReportGenreStatsModel
    {
        public string GenreName { get; set; }
        public int TimesInDB { get; set; } //temp name
        public int RowsInDB { get; set; }
        public double Precents => (TimesInDB / RowsInDB) * 100;
        public Tuple<string, int> Report => new Tuple<string, int>(GenreName, TimesInDB);
        public ReportGenreStatsModel()
        {

        }

        public ReportGenreStatsModel(string genreName, int trowsInDb, int rowsInDb)
        {
            GenreName = genreName;
            TimesInDB = trowsInDb;
            RowsInDB = rowsInDb;
        }
    }
}
