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
                .ForMember(m => m.Genre, o => o.MapFrom(s => string.Join(", ", s.Genre.Select(g => g.Name))))
                .ForMember(m => m.IsFavorite, o => o.Ignore());
            
        }
    }
}
