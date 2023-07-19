using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl,
            opt => opt.MapFrom(source => source.Photos.FirstOrDefault(p => p.IsMain).Url))
            .ForMember(des => des.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalcualteAge()));

            CreateMap<Photo, PhotoDto>();
        }
    }
}