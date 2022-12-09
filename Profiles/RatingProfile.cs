using AutoMapper;
using Jobify.Dto.Rating;
using Jobify.Dto.Response;
using Jobify.Models;

namespace Jobify.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<UpdateRatingDto, Rating>();
            CreateMap<CreateRatingDto, Rating>();
        }
    }
}
