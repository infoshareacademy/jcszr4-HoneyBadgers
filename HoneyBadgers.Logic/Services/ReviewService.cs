using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.Logic.Services
{
    public class ReviewService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Review> _reviewRepository;
        private readonly AuthService _authService;
        public ReviewService(AuthService authService, IRepository<Movie> movieRepository, IRepository<Review> reviewRepository)
        {
            _authService = authService;
            _movieRepository = movieRepository;
            _reviewRepository = reviewRepository;
        }

        public async Task<List<Review>> GetMovieReviews(string movieId)
        {
            var userId = _authService.GetUserId();
            var reviews  = await _reviewRepository.GetAllQueryable()
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
    }
}
