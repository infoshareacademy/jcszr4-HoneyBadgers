using System;
using System.Collections.Generic;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.RestApi.Services.Interfaces
{
    public interface IReportRepository
    {
        void AddReport(Report report);
        IEnumerable<Report> GetReports();
        Report GetReport(Guid id);
    }
}