using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Entity.Models;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<ApplicationUser> GetUsers();
        List<Movie> GetFavoriteMovies();
        void AddFavoriteMovie(string id);
        void RemoveFavoriteMovie(string id);
        Movie GetFavoriteMovie(string movieId);
    }
}