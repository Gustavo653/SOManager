using AutoMapper;
using Common.DTO;
using Microsoft.EntityFrameworkCore;
using SO.Domain;
using SO.DTO;
using SO.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SO.Application
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public TicketService(ITicketRepository ticketRepository,
                             IMapper mapper,
                             IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResponseDTO> CreateTicket(UserDTO userDTO, TicketDTO ticketDTO)
        {
            ResponseDTO responseDTO = new();
            try
            {
                var ticket = await _ticketRepository.GetTrackedEntities().FirstOrDefaultAsync(x => x.Protocol == ticketDTO.Protocol);
                if (ticket != null)
                {
                    var entityDTO = _mapper.Map<TicketDTO>(ticket);
                    responseDTO.Code = 400;
                    responseDTO.Message = "Este ticket já existe!";
                    responseDTO.Object = entityDTO;
                }
                else
                {
                    var user = await _userRepository.GetTrackedEntities().FirstOrDefaultAsync(x => x.UserName == userDTO.UserName);
                    var entity = _mapper.Map<Ticket>(ticketDTO);
                    entity.CreatedDate = DateTime.Now;
                    entity.CreatedBy = user;
                    await _ticketRepository.InsertAsync(entity);
                    await _ticketRepository.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                responseDTO.SetError(ex);
            }
            return responseDTO;
        }
        public Task<ResponseDTO> UpdateTicket(TicketDTO ticketDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> DeleteTicket(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDTO> GetTicket(long id)
        {
            throw new NotImplementedException();
        }

    }
}
