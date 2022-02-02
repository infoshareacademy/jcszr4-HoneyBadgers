using System.Linq;
using AutoMapper;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Dto;

namespace HoneyBadgers.Logic.MappingProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(m => m.IsFavorite, o => o.Ignore());
        }
    }
}
