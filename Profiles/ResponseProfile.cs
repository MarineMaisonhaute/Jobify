using AutoMapper;
using Jobify.Dto.Job;
using Jobify.Dto.Post;
using Jobify.Dto.Response;
using Jobify.Models;

namespace Jobify.Profiles
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<UpdateResponseDto, Response>();
            CreateMap<CreateResponseDto, Response>();
        }
    }
}
