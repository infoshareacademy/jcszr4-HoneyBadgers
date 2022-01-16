using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Dto;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.Logic.Services
{
    public class MovieService : IMovieService
    {
        private readonly UserService _userService;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;
        private readonly AuthService _authService;
        public MovieService(
            IRepository<Movie> movieRepository,
            UserService userService,
            IMapper mapper,
            AuthService authService)
        {
            _movieRepository = movieRepository;
            _userService = userService;
            _mapper = mapper;
            _authService = authService;
        }

        public async Task<List<MovieDto>> GetAllMovieShortModel()
        {
            
            var movies = await _movieRepository.GetAllQueryable()
                .Include(m => m.Genre)
                .Select(m => _mapper.Map<MovieDto>(m))
                .ToListAsync();
            var userFavoriteMovies = _userService.GetFavoriteMovies();
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

        public Movie GetById(string id)
        {
            return _movieRepository.Get(id);
        }

        public MovieDto GetMovieDtoById(string id)
        {
            var movie = _movieRepository.Get(id);
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<List<Movie>> GetRecent(int amount = 5)
        {
            return await _movieRepository.GetAllQueryable()
                .Include(m => m.Genre)
                .OrderByDescending(m => m.Released)
                .Take(amount)
                .ToListAsync();
        }
    }
}
