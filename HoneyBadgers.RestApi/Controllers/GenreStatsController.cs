using System;
using Microsoft.AspNetCore.Mvc;
using HoneyBadgers.RestApi.Models;
using HoneyBadgers.RestApi.Repositories;

namespace HoneyBadgers.RestApi.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IRepository<GenreStats> _repository;

        public GenreController(IRepository<GenreStats> repository)
        {
            _repository = repository ;
        }

        [HttpPost]
        public IActionResult AddGenreStats([FromBody] GenreStats stats)
        {
            _repository.Insert(stats);

            return Ok();
        }
        [HttpGet]
        public IActionResult TestError()
        {
            throw new InvalidOperationException("testujemy błedy");
        }


    }
}
