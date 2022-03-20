using HoneyBadgers.Logic.Services.Interfaces;
using HoneyBadgers.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    [Controller]
    [Route("report")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet]
        public ActionResult<ReportGenreStatsModel> Index()
        {
            return View();
        }


        [HttpGet]
        [Route("getreportdata")]
        public IActionResult GetReportData(string reportType)
        {
            var model = new ChartViewModel();
            switch (reportType)
            {
                case "genre-stats":
                    var genre = _reportService.GetAllGenreStatsReport().Result;
                    model.Title = "Genre Stats";
                    model.Description = "The most viewed genre by the number of views of movies in a given genre.";
                    model.ChartData = genre;
                    break;
                default:
                    // code block
                    break;
            }

            return PartialView("_ChartPartialView", model);
        }

        [HttpGet]
        [Route("useractivity")]
        public IActionResult GetUserActivityReport()
        {
            var model = _reportService.GetUsersActivity().Result;

            return View(model);
        }
    }
}