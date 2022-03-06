using System.Collections.Generic;
using HoneyBadgers.RestApi.Models;
using HoneyBadgers.RestApi.Repositories;
using HoneyBadgers.RestApi.Services.Interfaces;

namespace HoneyBadgers.RestApi.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Report> _repository;

        public ReportService(IRepository<Report> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Report> GetReports()
        {
            return _repository.GetAll();
        }

        public Report CreateReport()
        {
            var newReport = new Report();
            return newReport;
        }

        public void AddReport(Report report)
        {
            _repository.Insert(report);
        }

    }
}
