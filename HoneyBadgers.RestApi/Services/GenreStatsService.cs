using HoneyBadgers.RestApi.Models;
using HoneyBadgers.RestApi.Repositories;
using HoneyBadgers.RestApi.Services.Interfaces;

namespace HoneyBadgers.RestApi.Services
{
    public class GenreStatsService: IGenreStatsService
    {
        private readonly IRepository<GenreStats> _repository;

        public GenreStatsService(IRepository<GenreStats> repository)
        {
            _repository = repository;
        }

        void IGenreStatsService.Add(GenreStats genreStats)
        {
            _repository.Insert(genreStats);
        }
    }
}
