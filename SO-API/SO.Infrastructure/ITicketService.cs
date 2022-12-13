using Common.DTO;
using SO.DTO;

namespace SO.Infrastructure
{
    public interface ITicketService
    {
        Task<ResponseDTO> CreateTicket(UserDTO userDTO, TicketDTO ticketDTO);
        Task<ResponseDTO> UpdateTicket(long id, UserDTO userDTO, TicketDTO ticketDTO);
        Task<ResponseDTO> DeleteTicket(long id);
        Task<ResponseDTO> GetTicket(long id);
        Task<ResponseDTO> GetAll();
    }
}