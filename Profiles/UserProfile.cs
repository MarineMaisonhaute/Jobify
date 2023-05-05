using AutoMapper;
using Jobify.Dto.Job;
using Jobify.Dto.Post;
using Jobify.Dto.User;
using Jobify.Models;

namespace Jobify.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginDto, User>();
            CreateMap<UserSignUpDto, User>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth)));
        }
    }
}
