using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using Newtonsoft.Json;

namespace HoneyBadgers.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private IHttpClientFactory _iHttpClientFactory;
        public ReportController(IHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _iHttpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/reports");
            var result = await client.SendAsync(request);
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Report[]>(content); ;
            return View(json);
        }
    }
}
