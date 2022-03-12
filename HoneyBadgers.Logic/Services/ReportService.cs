using System.Net.Http;
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
        private readonly AuthService _authService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string baseUrl = "https://localhost:5001/api";
        public ReportService(IHttpClientFactory httpClientFactory, AuthService authService)
        {
            _httpClientFactory = httpClientFactory;
            _authService = authService;
        }

        //TODO: get
        //zwracac Tuple <(nazwa gatunku) String, (ilościowo) int>
        //możliwość wybory z jakiego okresu

        //TODO: stworzyć model raportu? 



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
        }
    }
}
