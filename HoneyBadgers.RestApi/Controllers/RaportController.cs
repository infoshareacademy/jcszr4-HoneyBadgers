﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HoneyBadgers.RestApi.Models;
using HoneyBadgers.RestApi.Services.Interfaces;
using System;

namespace HoneyBadgers.RestApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("reports")]
        public ActionResult<IEnumerable<ReportGenreStats>> GetReports()
        {
            var reports = _reportService.GetReports();

            if (reports == null)
            {
                return NoContent();
            }
            return Ok(reports);
        }

        [HttpGet]
        [Route("report/{id}")]
        public ActionResult<ReportGenreStats>GetReport(string id)
        {
            var result = _reportService.GetReportGenreStats(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenreStats([FromBody] GenreStats stats)
        {
            _reportService.InsertGenreStats(stats);
            return Ok();
        }

        [HttpPost]
        [Route("report/generate/{name}")]
        public IActionResult GenerateReportGenreStats(string name)
        {
            _reportService.InsertReportGenreStats(name);
            return Ok();
        }

        [HttpGet]
        [Route("report/last")]
        public ActionResult<ReportGenreStats> GetLastReport()
        {
            var result = _reportService.GetLastGeneratedReportGenreStats();
            return Ok(result);
        }

        [HttpGet]
        [Route("report/genrestats")]
        public ActionResult<List<Tuple<string,int>>> GetAllGenreStatsReport()
        {
            return _reportService.GetAllGenreReport();
        }

        [HttpPost]
        [Route("report/useractivity")]
        public IActionResult AddUserActivity(UserActivity userActivity)
        {
            
            _reportService.StoreUserActivity(userActivity.ActionArguments, userActivity.Url, userActivity.UserName, userActivity.IpAddress);

            return Ok(userActivity);
        }

    }
}
