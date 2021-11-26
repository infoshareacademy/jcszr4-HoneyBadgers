using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Repositories;
using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HoneyBadgers.Logic.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public List<Movie> GetSortMovie(FilterTypeEnum filterType)
        {
            var movies = GetAll();
            switch (filterType)
            {
                case FilterTypeEnum.ByMostPopularDescending:
                    movies = movies.OrderByDescending(m => m.ViewsNumber).ToList();
                    break;
                case FilterTypeEnum.ByMostPopularAscending:
                    movies = movies.OrderBy(m => m.ViewsNumber).ToList();
                    break;
                default:
                    break;
            }

            return movies;
        }

        public Movie GetById(string id)
        {
            return MovieRepository.Movies.SingleOrDefault(m => m.Id == id);
        }
    }
}
