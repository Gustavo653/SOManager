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
                    responseDTO.Object = ticketDTO;
                }
            }
            catch (Exception ex)
            {
                responseDTO.SetError(ex);
            }
            return responseDTO;
        }
        public async Task<ResponseDTO> UpdateTicket(long id, UserDTO userDTO, TicketDTO ticketDTO)
        {
            ResponseDTO responseDTO = new();
            try
            {
                var ticket = await _ticketRepository.GetTrackedEntities().FirstOrDefaultAsync(x => x.Id == id);
                if (ticket == null)
                {
                    responseDTO.Code = 400;
                    responseDTO.Message = "Este ticket não existe!";
                }
                else
                {
                    var user = await _userRepository.GetTrackedEntities().FirstOrDefaultAsync(x => x.UserName == userDTO.UserName);
                    var entity = _mapper.Map<Ticket>(ticketDTO);
                    entity.ChangedDate = DateTime.Now;
                    entity.ChangedBy = user;
                    _ticketRepository.Update(entity);
                    await _ticketRepository.SaveChangesAsync();
                    responseDTO.Object = ticketDTO;
                }
            }
            catch (Exception ex)
            {
                responseDTO.SetError(ex);
            }
            return responseDTO;
        }

        public async Task<ResponseDTO> DeleteTicket(long id)
        {
            ResponseDTO responseDTO = new();
            try
            {
                var ticket = await _ticketRepository.GetTrackedEntities().FirstOrDefaultAsync(x => x.Id == id);
                if (ticket == null)
                {
                    responseDTO.Code = 400;
                    responseDTO.Message = "Este ticket não existe!";
                }
                else
                {
                    _ticketRepository.Delete(ticket);
                    await _ticketRepository.SaveChangesAsync();
                    responseDTO.Object = ticket;
                }
            }
            catch (Exception ex)
            {
                responseDTO.SetError(ex);
            }
            return responseDTO;
        }

        public async Task<ResponseDTO> GetAll()
        {
            ResponseDTO responseDTO = new();
            try
            {
                var ticket = await _ticketRepository.GetTrackedEntities().ToListAsync();
                if (!ticket.Any())
                {
                    responseDTO.Code = 200;
                    responseDTO.Message = "Não existem tickets cadastrados!";
                }
                else
                {
                    responseDTO.Object = ticket;
                }
            }
            catch (Exception ex)
            {
                responseDTO.SetError(ex);
            }
            return responseDTO;
        }

        public async Task<ResponseDTO> GetTicket(long id)
        {
            ResponseDTO responseDTO = new();
            try
            {
                var ticket = await _ticketRepository.GetTrackedEntities().FirstOrDefaultAsync(x => x.Id == id || x.Protocol == id.ToString());
                if (ticket == null)
                {
                    responseDTO.Code = 200;
                    responseDTO.Message = "O ticket não foi encontrado!";
                }
                else
                {
                    responseDTO.Object = ticket;
                }
            }
            catch (Exception ex)
            {
                responseDTO.SetError(ex);
            }
            return responseDTO;
        }

    }
}
