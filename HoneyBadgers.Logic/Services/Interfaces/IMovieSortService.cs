
using System.Collections.Generic;

using HoneyBadgers.Logic.Dto;
using HoneyBadgers.Logic.Enums;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IMovieSortService
    {
        List<MovieDto> FindMovieWithRatingBetweenLowerHigher(List<MovieDto> movies, double lowestRating,
            double highestRating);

        List<MovieDto> SortMovie(List<MovieDto> sortedMovies, SortType sortType);
    }
}
