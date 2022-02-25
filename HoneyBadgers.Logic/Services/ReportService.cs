﻿using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using Newtonsoft.Json;

namespace HoneyBadgers.Logic.Services
{
    public class ReportService: IReportService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl = "https://localhost:44313/api";
        public ReportService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task AddGenreStats(CreateGenreStats genreStats)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(
                JsonConvert.SerializeObject(genreStats),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            var result = await client.PostAsync($"{baseUrl}/genre", content);
            var cos = result;
        }
    }
}
