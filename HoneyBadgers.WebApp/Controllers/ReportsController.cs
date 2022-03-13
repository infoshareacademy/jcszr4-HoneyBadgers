using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using HoneyBadgers.WebApp.Models;
using System.Collections.Generic;

namespace HoneyBadgers.WebApp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IHttpClientFactory _iHttpClientFactory;
        private readonly string _baseUrl = @"https://localhost:5001/api";
        public ReportsController(IHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }
        [HttpGet]
        public async Task<ActionResult<GenreStats>> Index()
        public async Task<ActionResult<IEnumerable<ReportGenreStats>>> Index()
        {
            var client = _iHttpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/reports");

            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                return View(new GenreStats[] { new GenreStats()});
                return View(new ReportGenreStats[] { new ReportGenreStats()});
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<GenreStats[]>(content);
            var json = JsonConvert.DeserializeObject<ReportGenreStats[]>(content);
            return View(json);
        }
        [HttpGet]
        
        // GET: MovieController/Details/5
        public async Task<IActionResult> Details(string name)
        {
            var client = _iHttpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/report/{name}");
            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<ReportGenreStatsModel[]>(content);
            return View(json);
        }
        [HttpPost]
        public async Task<IActionResult> GenerateReport(string name)
        {
            var client = _iHttpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/report/generate/{name}");
            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<ReportGenreStats>(content);
            return View(Index());

        }

    }
}
