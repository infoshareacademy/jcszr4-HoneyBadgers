using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Repositories;
using HoneyBadgers.Logic.Repositories.Interfaces;
using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
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
        public List<MovieViewModel> GetSortMovie(List<MovieViewModel> sortedMovies, SortType sortType)
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
            return MovieRepository.Movies.SingleOrDefault(m => m.Id == id);
        }
    }
}
