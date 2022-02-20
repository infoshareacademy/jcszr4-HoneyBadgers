﻿using HoneyBadgers.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.RestApi.Services.Interfaces;

namespace HoneyBadgers.RestApi.Services
{
    public class ReportRepository : IReportRepository
    {
        private readonly List<Report> _reports;

        public ReportRepository()
        {
            _reports = new()
            {
                new Report(),
                new Report(),
                new Report(),
                new Report(),
                new Report(),
                new Report(),
                new Report(),
                new Report(),
                new Report()
            };
        }

        public void AddReport(Report report)
        {
            _reports.Add(report);
        }

        public IEnumerable<Report> GetReports()
        {
            return _reports;
        }

        public Report GetReport(Guid id)
        {
            return _reports.First(r => r.Id == id);
        }

    }

    
}
