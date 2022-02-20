using System.Linq;
using AutoMapper;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Dto;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.IsFavorite, o => o.Ignore());
            CreateMap<Movie, DetailMovieViewModel>()
                .ForMember(m => m.IsFavorite, o => o.Ignore());
        }
    }
}
