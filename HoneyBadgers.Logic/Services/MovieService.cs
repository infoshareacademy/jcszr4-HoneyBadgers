using HoneyBadgers.Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBadgers.Logic.Services
{
    public class MovieService
    {
        private MovieRepository _movieRepository;
        public MovieService()
        {
            _movieRepository = new MovieRepository();
        }

        public List<Movie> GetAll()
        {
            return MovieRepository.Movies;
        }
    }
}
