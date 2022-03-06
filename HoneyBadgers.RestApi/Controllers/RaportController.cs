using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HoneyBadgers.RestApi.Models;
using HoneyBadgers.RestApi.Services.Interfaces;

namespace HoneyBadgers.RestApi.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Report>> GetReports()
        {
            var reports = _reportService.GetReports();
            if (reports == null)
            {
                return NoContent();
            }
            return Ok(reports);
        }

    }
}
