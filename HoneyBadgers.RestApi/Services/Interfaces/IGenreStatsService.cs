using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers.RestApi.Models;

namespace HoneyBadgers.RestApi.Services.Interfaces
{
    public interface IGenreStatsService
    {
        void Add(GenreStats genreStats);
    }
}
