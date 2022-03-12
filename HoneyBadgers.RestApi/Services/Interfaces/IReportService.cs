using HoneyBadgers.RestApi.Models;
using System.Collections.Generic;

namespace HoneyBadgers.RestApi.Services.Interfaces
{
    public interface IReportService
    {
        IEnumerable<GenreStats> GetGenreStats();
        ReportGenreStats GetReportGenreStats(string id);
        void InsertGenreStats(GenreStats genreStats);
        void InsertReportGenreStats(string name);
        IEnumerable<ReportGenreStats> GetReports();
    }
}