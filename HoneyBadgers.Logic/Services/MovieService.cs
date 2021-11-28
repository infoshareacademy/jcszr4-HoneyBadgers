using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Repositories;
using HoneyBadgers.Logic.Repositories.Interfaces;
using HoneyBadgers.Logic.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public List<Movie> GetSortMovie(List<Movie> moviesToSort, SortType sortType)
        {
            switch (sortType)
            {
                case SortType.ByMostPopularDescending:
                    moviesToSort = moviesToSort.OrderByDescending(m => m.ViewsNumber).ToList();
                    break;
                case SortType.ByMostPopularAscending:
                    moviesToSort = moviesToSort.OrderBy(m => m.ViewsNumber).ToList();
                    break;
            }

            return moviesToSort;
        }

        public Movie GetById(string id)
        {
            return MovieRepository.Movies.SingleOrDefault(m => m.Id == id);
        }
    }
}
