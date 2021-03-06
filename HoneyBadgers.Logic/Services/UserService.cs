using System;
using HoneyBadgers.Entity.Context;
using HoneyBadgers.Entity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Logic.Services.Interfaces;

namespace HoneyBadgers.Logic.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;
        private readonly HbContext _hbContext;
        public UserService(UserManager<ApplicationUser> userManager, IAuthService authService, HbContext hbContext)
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
        public void AddFavoriteMovie(string id)
        {
            _hbContext.UserMovie.AsQueryable();
            var userId = _authService.GetUser().Result;
            if (userId == null)
            {
                return;
            }
            var movieToAdd = _hbContext.Movies.AsQueryable().FirstOrDefault(m => m.Id == id);
            
            var favMovie = new FavoriteMovie()
            {
                MovieId = movieToAdd?.Id,
                UserId = userId.Id
            };
            _hbContext.Add(favMovie);
            _hbContext.SaveChanges();
        }

        public void RemoveFavoriteMovie(string id)
        {
            var userId = _authService.GetUser().Result;
            var mov = _hbContext.FavoriteMovies.Where(m => m.MovieId == id && m.UserId == userId.Id).AsQueryable()
                .First();
            _hbContext.FavoriteMovies.Remove(mov);
            _hbContext.SaveChanges();
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
                .FirstOrDefault();
            return userFavoriteMovie;

        }
    }
}
