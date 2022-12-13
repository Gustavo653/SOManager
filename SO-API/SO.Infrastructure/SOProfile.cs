using AutoMapper;
using SO.Domain;
using SO.Domain.Identity;
using SO.DTO;

namespace SO.Infrastructure
{
    public class SOProfile : Profile
    {
        public SOProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<Ticket, TicketDTO>().ReverseMap();
        }
    }
}