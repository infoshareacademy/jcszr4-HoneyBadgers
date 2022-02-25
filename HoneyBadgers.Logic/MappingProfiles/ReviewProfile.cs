using AutoMapper;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Models;

namespace HoneyBadgers.Logic.MappingProfiles
{
    class ReviewProfile: Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewViewModel>();
        }
    }
}
