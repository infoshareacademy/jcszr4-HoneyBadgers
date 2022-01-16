using System.Collections.Generic;
using HoneyBadgers.Logic.Repositories;
using System.Linq;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services.Interfaces;

namespace HoneyBadgers.Logic.Services
{
    public class FavoriteMoviesService : IFavoriteMoviesService
    {
        private IMovieService _movieService { get; }
        private IFavoriteMoviesRepository _favoriteMovies { get; set; }

        public FavoriteMoviesService(IFavoriteMoviesRepository favoriteMovies, IMovieService movieService)
        {
            _favoriteMovies = favoriteMovies;
            _movieService = movieService;
        }

        public List<string> GetAllFavoriteMovieId()
        {
            return _favoriteMovies.GetAll();
        }

        public List<MovieViewModel> GetAllMoviesAsMovieViewModels()
        {
            var movieViewModels = new List<MovieViewModel>();
            var movies = _movieService.GetAll();
            var favorite = GetAllFavoriteMovieId();
            foreach (var movie in movies)
            {
                var favoriteMovie = new MovieViewModel
                {
                    Actors = movie.Actors,
                    Country = movie.Country,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    Id = movie.Id,
                    ImdbRating = movie.ImdbRating,
                    Plot = movie.Plot,
                    Poster = movie.Poster,
                    Ratings = movie.Ratings,
                    Writer = movie.Writer,
                    ViewsNumber = movie.ViewsNumber,
                    Year = movie.Year,
                    Title = movie.Title,
                    IsFavorite = favorite.Find(f => f == movie.Id) != null
                };
                movieViewModels.Add(favoriteMovie);
            }

            return movieViewModels;
        }

        public List<FavoriteMoviesViewModel> GetAllFavoriteMoviesViewModels()
        {
            var movieViewModels = new List<FavoriteMoviesViewModel>();
            var movies = _movieService.GetAll();
            var favorite = GetAllFavoriteMovieId();
            foreach (var movie in movies)
            {
                var favoriteMovie = new FavoriteMoviesViewModel
                {
                    Actors = movie.Actors,
                    Country = movie.Country,
                    Director = movie.Director,
                    Genre = movie.Genre,
                    Id = movie.Id,
                    ImdbRating = movie.ImdbRating,
                    Plot = movie.Plot,
                    Poster = movie.Poster,
                    Ratings = movie.Ratings,
                    Writer = movie.Writer,
                    ViewsNumber = movie.ViewsNumber,
                    Year = movie.Year,
                    Title = movie.Title,
                    IsFavorite = favorite.Find(f => f == movie.Id) != null
                };
                movieViewModels.Add(favoriteMovie);
            }

            return movieViewModels;
        }

    

    public void AddFavorite(string id)
        {
            if (_favoriteMovies.GetAll().Any(m => m == id))
            {
                return;
            }

            _favoriteMovies.AddFavorite(id);
        }

        public void RemoveFavorite(string id)
        {
            _favoriteMovies.RemoveFavorite(id);
        }
    }
}