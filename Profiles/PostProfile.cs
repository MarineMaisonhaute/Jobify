using AutoMapper;
using Jobify.Dto.Job;
using Jobify.Dto.Post;
using Jobify.Models;

namespace Jobify.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<UpdatePostDto, Post>();
            CreateMap<CreatePostDto, Post>();
        }
    }
}
