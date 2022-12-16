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
            CreateMap<User, UserDTO>(MemberList.None).ReverseMap();
            CreateMap<User, UserLoginDto>(MemberList.None).ReverseMap();
            CreateMap<Ticket, TicketDTO>(MemberList.None).ReverseMap();
        }
    }
}