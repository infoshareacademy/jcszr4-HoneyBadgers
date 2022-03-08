using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IReportService
    {
        public Task AddGenreStats(CreateGenreStats genreStats);
        public List<Tuple<string, int>> GetGenreStats();
    }
}