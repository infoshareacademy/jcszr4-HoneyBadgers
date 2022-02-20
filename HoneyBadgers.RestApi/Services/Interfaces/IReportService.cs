using System.Collections.Generic;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.RestApi.Services.Interfaces
{
    public interface IReportService
    {
        IEnumerable<Report> GetReports();
        Report CreateReport();
        void AddReport(Report report);
    }
}