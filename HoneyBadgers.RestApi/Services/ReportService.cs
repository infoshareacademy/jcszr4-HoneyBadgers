using HoneyBadgers.RestApi.Models;
using HoneyBadgers.RestApi.Repositories;
using HoneyBadgers.RestApi.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.RestApi.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<ReportGenreStats> _reportGenreStatsRepository;
        private readonly IRepository<GenreStats> _genreStatsRepository;

        public ReportService(IRepository<GenreStats> genreStatsRepository, IRepository<ReportGenreStats> reportGenreStatsRepository)
        {
            _genreStatsRepository = genreStatsRepository;
            _reportGenreStatsRepository = reportGenreStatsRepository;
        }

        public void InsertGenreStats(GenreStats genreStats)
        {
            _genreStatsRepository.Insert(genreStats);
        }
        public IEnumerable<GenreStats> GetGenreStats()
        {
            return _genreStatsRepository.GetAllQueryable();
        }
        public void InsertReportGenreStats(string name)
        {
            var numberOfRecords = _genreStatsRepository.GetAllQueryable().Count();
            var numberOfGenre = _genreStatsRepository.GetAllQueryable().Count(r => r.GenreName == name);

            var report = new ReportGenreStats(name, numberOfGenre, numberOfRecords);  
        }
        public ReportGenreStats GetReportGenreStats(string id)
        {
            var report = _reportGenreStatsRepository.Get(id);
            return report;
        }

        public IEnumerable<ReportGenreStats> GetReports()
        {
            return _reportGenreStatsRepository.GetAllQueryable();
        }
    }
}
