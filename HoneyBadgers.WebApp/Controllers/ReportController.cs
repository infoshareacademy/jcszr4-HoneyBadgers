using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using HoneyBadgers.WebApp.Models;
using Newtonsoft.Json;

namespace HoneyBadgers.WebApp.Controllers
{
    public class ReportController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly IReportService _reportService;
        public ReportController(IHttpClientFactory httpClientFactory, IReportService reportService)
        {
            //_httpClientFactory = httpClientFactory; // czy my tego potrzebujemy tu? Może to załatwiać service w logice
            _reportService = reportService;
        }
        [HttpGet]
        public async Task<ActionResult<ReportGenreStatsModel>> Index()
        {
            //TODO: chyba do wywalenia ??????
            // var client = _iHttpClientFactory.CreateClient();
            // var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/reports");
            //
            // HttpResponseMessage result;
            // try
            // {
            //     result = await client.SendAsync(request);
            // }
            // catch(Exception ex)
            // {
            //     return View(new Report[]{ new Report(ex.Message) });
            // }
            // var content = await result.Content.ReadAsStringAsync();
            // var json = JsonConvert.DeserializeObject<Report[]>(content); 
            return View();
        }


        [HttpGet]
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
    }
}