using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AutoMapper;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Dto;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace HoneyBadgers.Logic.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MovieService(IRepository<Movie> movieRepository, IRepository<User> userRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<MovieDto>> GetAllMovieShortModel(int userId)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;
            var userFavoriteMovies = _userRepository.GetAllQueryable()
                .Where(u => u.Id == userId)
                .SelectMany(u => u.FavoriteMovies.Select(fm => fm.Movie))
                .ToList();
            var movies = await _movieRepository.GetAllQueryable()
                .Include(m => m.Genre)
                .Select(m => _mapper.Map<MovieDto>(m))
                .ToListAsync();
            movies.ForEach(m => m.IsFavorite = userFavoriteMovies.Any(f => f.Id == m.Id));
            return movies;
        }

        public async Task<List<Movie>> GetAll()
        {
            return await _movieRepository.GetAllQueryable()
                .Include(m => m.Genre)
                .ToListAsync();
        }

        public List<Movie> GetSortMovie(List<Movie> sortedMovies, SortType sortType)
        {
            switch (sortType)
            {
                case SortType.ByMostPopularDescending:
                    sortedMovies = sortedMovies.OrderByDescending(m => m.ViewsNumber).ToList();
                    break;
                case SortType.ByMostPopularAscending:
                    sortedMovies = sortedMovies.OrderBy(m => m.ViewsNumber).ToList();
                    break;
            }

            return sortedMovies;
        }
        public List<MovieDto> GetSortMovie(List<MovieDto> sortedMovies, SortType sortType)
        {
            switch (sortType)
            {
                case SortType.ByMostPopularDescending:
                    sortedMovies = sortedMovies.OrderByDescending(m => m.ViewsNumber).ToList();
                    break;
                case SortType.ByMostPopularAscending:
                    sortedMovies = sortedMovies.OrderBy(m => m.ViewsNumber).ToList();
                    break;
            }

            return sortedMovies;
        }

        public Movie GetById(int id)
        {
            return _movieRepository.Get(id);
        }
    }
}
