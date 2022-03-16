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
        private readonly AuthService _authService;
        private readonly ILogger<ReportService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://localhost:5001/api";
        public ReportService(IHttpClientFactory httpClientFactory, AuthService authService, ILogger<ReportService> logger)
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
            var result = await client.PostAsync($"{_baseUrl}/genre", content);

            if (!result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                _logger.LogError($"Error while creating genre stats report: {resultContent}");
            }
        }

        public async  Task<IEnumerable<ReportGenreStats>> GetAllReports()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/reports");

            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                result = new HttpResponseMessage(); // TODO coś z tym jeszcze musze zrobić
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<ReportGenreStats[]>(content);
            return json;
        }

        public async Task<ReportGenreStats> GetReportById(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/report/{id}");
            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                result = new HttpResponseMessage(); // TODO coś z tym jeszcze musze zrobić
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<ReportGenreStats>(content);
            return json;
        }
        public async Task GenerateReportGenreStats(string genreName) {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/report/generate/{genreName}");
            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                result = new HttpResponseMessage(); // TODO coś z tym jeszcze musze zrobić
            }
            //chwilowo na czas testu zakomentowane - prawdopodobnie do wywalenia
            //var content = await result.Content.ReadAsStringAsync(); 
            //var json = JsonConvert.DeserializeObject<ReportGenreStats>(content);
        }
        public async Task<Tuple<string,int>> GetLastReportGenreStats()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/report/last");
            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            } 
            catch(Exception ex)
            {
                result = new HttpResponseMessage(); // TODO coś z tym jeszcze musze zrobić
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<ReportGenreStats>(content);
            return json.ReportAsTuple;
        }

        public async Task<List<Tuple<string, int>>> GetAllGenreStatsReport()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/report/genrestats");
            HttpResponseMessage result;
            try
            {
                result = await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                result = new HttpResponseMessage(); // TODO coś z tym jeszcze musze zrobić
            }
            var content = await result.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<List<Tuple<string, int>>>(content);
            return json;
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
