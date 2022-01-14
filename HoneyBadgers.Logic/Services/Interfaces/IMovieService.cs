﻿using HoneyBadgers.Logic.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Dto;

namespace HoneyBadgers.Logic.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAll();
        Movie GetById(string id);
        List<Movie> GetSortMovie(List<Movie> sortedMovies, SortType sortType);
        List<MovieDto> GetSortMovie(List<MovieDto> sortedMovies, SortType sortType);
        Task<List<MovieDto>> GetAllMovieShortModel();
        Task<List<Movie>> GetRecent(int amount = 5);
    }
}
