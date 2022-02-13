using HoneyBadgers.Entity.Models;
using HoneyBadgers.RestApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HoneyBadgers.RestApi.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportController
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IEnumerable<Report> GetReports()
        {
            var reports = _reportService.GetReports();
            return reports;
        }

    }
}
