using System.Threading.Tasks;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IReportService
    {
        public Task AddGenreStats(CreateGenreStats genreStats);
    }
}