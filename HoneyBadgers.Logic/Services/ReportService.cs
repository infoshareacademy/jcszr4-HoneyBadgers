using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HoneyBadgers.Logic.Services
{
    public class ReportService: IReportService
    {
        private readonly IAuthService _authService;
        private readonly ILogger<ReportService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl = "https://localhost:5001/api";
        public ReportService(IHttpClientFactory httpClientFactory, IAuthService authService, ILogger<ReportService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _authService = authService;
            _logger = logger;
        }
        public async Task AddGenreStats(CreateGenreStats genreStats)
        {
            var user = await _authService.GetUser();
            if (user != null)
            {
                genreStats.UserEmail = user.Email;
                genreStats.UserId = user.Id;
            }
            else
            {
                genreStats.UserEmail = "Guest";
                genreStats.UserId = Guid.Empty.ToString();
            }
            
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(
                JsonConvert.SerializeObject(genreStats),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            var result = await client.PostAsync($"{baseUrl}/genre", content);

            if (!result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                _logger.LogError($"Error while creating genre stats report: {resultContent}");
            }
        }

        public List<Tuple<string, int>> GetGenreStats()
        {
            var genre = new List<Tuple<string, int>>();
            genre.Add(new Tuple<string, int>("Action", 3));
            genre.Add(new Tuple<string, int>("Horror", 8));
            genre.Add(new Tuple<string, int>("Fantasy", 6));
            genre.Add(new Tuple<string, int>("Comedy", 10));
            genre.Add(new Tuple<string, int>("Romance", 1));
            genre.Add(new Tuple<string, int>("Thriller", 1));
            genre.Add(new Tuple<string, int>("Western", 1));

            return genre;
        }
    }
}
