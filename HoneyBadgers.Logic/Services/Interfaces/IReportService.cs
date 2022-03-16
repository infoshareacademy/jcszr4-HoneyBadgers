using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IReportService
    {
        Task AddGenreStats(CreateGenreStats genreStats);
        List<Tuple<string, int>> GetGenreStats();
        Task<IEnumerable<ReportGenreStats>> GetAllReports();
        Task<ReportGenreStats> GetReportById(string id);
        Task GenerateReportGenreStats(string genreName);
        Task<Tuple<string,int>> GetLastReportGenreStats();
        Task<List<Tuple<string, int>>> GetAllGenreStatsReport();
    }
}