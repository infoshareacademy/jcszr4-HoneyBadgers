using HoneyBadgers.Logic.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Dto;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Movie GetById(string id);
        Task<DetailMovieViewModel> GetDetailMovie(string id);
        Task<List<MovieDto>> GetAllMovieShortModel();
        Task<List<Movie>> GetRecent(int amount = 5);
    }
}
