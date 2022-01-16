using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Context;
using HoneyBadgers.Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HoneyBadgers.Logic.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthService _authService;
        private readonly HbContext _hbContext;
        public UserService(UserManager<ApplicationUser> userManager, AuthService authService, HbContext hbContext)
        {
            _userManager = userManager;
            _authService = authService;
            _hbContext = hbContext;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {

            return _userManager.Users;
        }

        public List<Movie> GetFavoriteMovies()
        {
            var userId = _authService.GetUserId();
            var userFavoriteMovies = _hbContext.FavoriteMovies.AsQueryable()
                .Where(u => u.UserId == userId)
                .Include(u => u.Movie)
                .Select(m => m.Movie)
                .ToList();
            return userFavoriteMovies;
        }

        public Movie GetFavoriteMovie(string movieId)
        {
            var userId = _authService.GetUserId();
            var userFavoriteMovie = _hbContext.FavoriteMovies.AsQueryable()
                .Where(u => u.UserId == userId)
                .Where(m => m.MovieId == movieId)
                .Include(u => u.Movie)
                .Select(m => m.Movie)
                .ToList()
                .First();
            return userFavoriteMovie;
        }
    }
}
