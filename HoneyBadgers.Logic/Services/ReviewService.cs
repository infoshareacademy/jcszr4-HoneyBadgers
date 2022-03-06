using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.Logic.Services
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllMovieReviews(string movieId);
        Task<List<Review>> GetMovieReviews(string movieId);
        void Create(Review review);
        Review GetById(string id);
        string Delete(string id);
        Task<ReviewViewModel> GetDetails(string id);
        Task<List<Review>> GetUserReviews(string movieId);
        Task<List<Review>> GetRecentReviews();
        void Update(Review action);
    }
    public class ReviewService: IReviewService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly AuthService _authService;
        private readonly IMapper _mapper;
        public ReviewService(AuthService authService,
            IRepository<Movie> movieRepository,
            IRepository<Review> reviewRepository,
            IMapper mapper)
        {
            _authService = authService;
            _movieRepository = movieRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<Review>> GetAllMovieReviews(string movieId)
        {
            var reviews  = await _reviewRepository.GetAllQueryable()
                .Include(r => r.Movie)
                .Include(r => r.User)
                .Where(r => r.MovieId == movieId)
                .ToListAsync();
            return reviews;
        }

        public async Task<List<Review>> GetMovieReviews(string movieId)
        {
            var reviews = await _reviewRepository.GetAllQueryable()
                .Include(r => r.Movie)
                .Include(r => r.User)
                .Where(r => r.MovieId == movieId)
                .Take(3)
                .ToListAsync();
            return reviews;
        }

        public async Task<List<Review>> GetUserReviews(string movieId)
        {
            var userId = _authService.GetUserId();
            var reviews = await _reviewRepository.GetAllQueryable()
                .Include(r => r.Movie)
                .Include(r => r.User)
                .Where(r => r.MovieId == movieId && r.UserId == userId)
                .ToListAsync();
            return reviews;
        }

        public void Create(Review review)
        {
            var userId = _authService.GetUserId();
            review.UserId = userId;
            _reviewRepository.Insert(review);
        }

        public void Update(Review action)
        {
            var review = _reviewRepository.Get(action.Id);
            review.Title = action.Title;
            review.Body = action.Body;

            _reviewRepository.Update(review);
        }

        public async Task<ReviewViewModel> GetDetails(string id)
        {
            var review = await _reviewRepository.GetAllQueryable()
                .Include(r => r.Movie)
                .ThenInclude(m => m.Genre)
                .Include(r => r.User)
                .Where(r => r.Id == id)
                .SingleOrDefaultAsync();
            var reviewDetail = _mapper.Map<ReviewViewModel>(review);
            reviewDetail.Movie = _mapper.Map<Movie, DetailMovieViewModel>(review.Movie);
            return reviewDetail;
        }

        public Review GetById(string id)
        {
            return _reviewRepository.Get(id);
        }

        public string Delete(string id)
        {
            var review = GetById(id);
            _reviewRepository.Delete(review);
            return review.MovieId;
        }

        public async Task<List<Review>> GetRecentReviews()
        {
            var reviews = await _reviewRepository.GetAllQueryable()
                .Include(r => r.Movie)
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedDate)
                .Take(2)
                .ToListAsync();
            return reviews;
        }
    }
}
