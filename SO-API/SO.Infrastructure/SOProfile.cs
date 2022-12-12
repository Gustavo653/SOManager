using AutoMapper;
using SO.Domain.Identity;
using SO.DTO;

namespace SO.Infrastructure
{
    public class SOProfile : Profile
    {
        public SOProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}