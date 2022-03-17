using System.Collections.Generic;
using System.Linq;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Entity.Repositories;
using HoneyBadgers.Logic.Dto;
using HoneyBadgers.Logic.Enums;
using HoneyBadgers.Logic.Services.Interfaces;


namespace HoneyBadgers.Logic.Services
{
    public class MovieSortService: IMovieSortService
    {
        public List<MovieDto> FindMovieWithRatingBetweenLowerHigher(List<MovieDto> movies, double lowestRating, double highestRating)
        {
            return movies.Where(movie => movie.ImdbRating >= lowestRating && movie.ImdbRating <= highestRating)
                .OrderByDescending(movie => movie.ImdbRating)
                .ToList();
        }

        public List<MovieDto> SortMovie(List<MovieDto> movies, SortType sortType)
        {
            var sortedMovies = new List<MovieDto>();
            switch (sortType)
            {
                case SortType.ByMostPopularDescending:
                    sortedMovies = movies.OrderByDescending(m => m.ViewsNumber).ToList();
                    break;
                case SortType.ByMostPopularAscending:
                    sortedMovies = movies.OrderBy(m => m.ViewsNumber).ToList();
                    break;
                case SortType.ByRatingDescending:
                    sortedMovies = movies.OrderByDescending(movie => movie.ImdbRating).ToList();
                    break;
                case SortType.ByRatingAscending:
                    sortedMovies = movies.OrderBy(movie => movie.ImdbRating).ToList();
                    break;
                case SortType.ByYearDescending:
                    sortedMovies = movies.OrderByDescending(movie => movie.Year).ToList();
                    break;
                case SortType.ByYearAscending:
                    sortedMovies = movies.OrderBy(movie => movie.Year).ToList();
                    break;
            }
            return sortedMovies;
        }
    }
}