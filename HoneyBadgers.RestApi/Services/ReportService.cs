using HoneyBadgers.Entity.Models;
using System.Collections.Generic;
using HoneyBadgers.RestApi.Services.Interfaces;

namespace HoneyBadgers.RestApi.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;

        public ReportService(IReportRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Report> GetReports()
        {
            return _repository.GetReports();
        }

        public Report CreateReport()
        {
            var newReport = new Report();
            return newReport;
        }

        public void AddReport(Report report)
        {
            _repository.AddReport(report);
        }

    }
}
