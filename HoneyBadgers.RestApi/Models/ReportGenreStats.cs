using System;

namespace HoneyBadgers.RestApi.Models
{
    public class ReportGenreStats : BaseEntity
    {
        public string GenreName { get; init; }
        public int TimesInDB { get; init; }
        public int RowsInDB { get; init; }
        public double Precents { get; set; }
    
        public Tuple<string, int> ReportAsTuple => new Tuple<string, int>(GenreName, TimesInDB);

        public string Body { get; set; }

        
        public ReportGenreStats()
        {
            GenreName = "empty";
            TimesInDB = 0;
            RowsInDB = 0;
            Body = $"GenreName: {GenreName}; TimesInDb: {TimesInDB}; RowsInDb: {RowsInDB}; Percent: {Precents}%; ReportAsTuple: {ReportAsTuple.Item1}{ReportAsTuple.Item2}";
            Precents = 0.0;
        }

        public ReportGenreStats(string genreName, int trowsInDb, int rowsInDb)
        {
            GenreName = genreName;
            TimesInDB = trowsInDb;
            RowsInDB = rowsInDb;
            Body = $"GenreName: {GenreName}; TimesInDb: {TimesInDB}; RowsInDb: {RowsInDB}; Percent: {Precents}%; ReportAsTuple: {ReportAsTuple.Item1}{ReportAsTuple.Item2}";
            Precents = TimesInDB / RowsInDB * 100;

        }
    }
}
