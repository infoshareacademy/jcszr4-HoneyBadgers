using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.WebApp.Models;
using Newtonsoft.Json;

namespace HoneyBadgers.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IHttpClientFactory _iHttpClientFactory;
        public ReportController(IHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }
        [HttpGet]
        public async Task<ActionResult<Report>> Index()
        {
            var client = _iHttpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:5001/api/reports");

            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch(Exception ex)
            {
                return View(new Report[]{ new Report(ex.Message) });
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<Report[]>(content); 
            return View(json);
        }

    }
}
