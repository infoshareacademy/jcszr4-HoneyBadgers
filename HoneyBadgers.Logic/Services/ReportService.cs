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
        private readonly AuthService _authService;
        private readonly ILogger<ReportService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl = "https://localhost:44313/api";
        public ReportService(IHttpClientFactory httpClientFactory, AuthService authService, ILogger<ReportService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _authService = authService;
            _logger = logger;
        }
        public async Task AddGenreStats(CreateGenreStats genreStats)
        {
            var user = await _authService.GetUser();
            genreStats.UserEmail = user.Email;
            genreStats.UserId = user.Id;
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
    }
}
