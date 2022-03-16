using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Dto;
using HoneyBadgers.Logic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.Logic.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUserService _userService;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;
        private readonly IAuthService _authService;
        public MovieService(
            IRepository<Movie> movieRepository,
            IUserService userService,
            IMapper mapper,
            IReviewService reviewService,
            IAuthService authService)
        {
            _movieRepository = movieRepository;
            _userService = userService;
            _mapper = mapper;
            _reviewService = reviewService;
            _authService = authService;
        }

        public async Task<List<MovieDto>> GetAllMovieShortModel()
        {
            var movies = await _movieRepository.GetAllQueryable()
                .Include(m => m.Genre)
                .Include(m => m.Reviews)
                .Select(m => _mapper.Map<MovieDto>(m))
                .ToListAsync();
            var userFavoriteMovies = _userService.GetFavoriteMovies();
            movies.ForEach(m => m.IsFavorite = userFavoriteMovies.Any(f => f.Id == m.Id));
            var userId = _authService.GetUserId();
            if (userId != null)
            {
                movies.ForEach(m =>
                {
                    var userReview = m.Reviews.Find(r => r.UserId == userId);
                    m.UserReviewId = userReview?.Id;
                });
            }
            return movies;
        }

        public async Task<List<Movie>> GetAll()
        {
            return await _movieRepository.GetAllQueryable()
                .Include(m => m.Genre)
                .ToListAsync();
        }

        public Movie GetById(string id)
        {
            return _movieRepository.Get(id);
        }

        public async Task<DetailMovieViewModel> GetDetailMovie(string id)
        {
            var movie = await _movieRepository.GetAllQueryable()
                .Include(m => m.Genre)
                .Include(m => m.Ratings)
                .SingleOrDefaultAsync(m => m.Id == id);
            movie.Reviews = await _reviewService.GetMovieReviews(id);
            var userFavoriteMovies = _userService.GetFavoriteMovies();
            var detailMovie = _mapper.Map<DetailMovieViewModel>(movie);
            detailMovie.IsFavorite = userFavoriteMovies.Any(m => m.Id == id);
            return detailMovie;
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
