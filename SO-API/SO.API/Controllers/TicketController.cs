using Common.Functions;
using Microsoft.AspNetCore.Mvc;
using SO.Application;
using SO.DTO;
using SO.Infrastructure;
using System.Threading.Tasks;

namespace SO.API.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;
        private readonly IAccountService _accountService;

        public TicketController(ITicketService ticketService, IAccountService accountService)
        {
            _ticketService = ticketService;
            _accountService = accountService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketDTO ticketDTO)
        {
            var userDTO = await _accountService.GetUserByUserNameAsync(User.GetUserName());
            var data = await _ticketService.CreateTicket(userDTO, ticketDTO);
            return StatusCode(data.Code, data);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] long id, [FromBody] TicketDTO ticketDTO)
        {
            var userDTO = await _accountService.GetUserByUserNameAsync(User.GetUserName());
            var data = await _ticketService.UpdateTicket(id, userDTO, ticketDTO);
            return StatusCode(data.Code, data);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] long id)
        {
            var data = await _ticketService.DeleteTicket(id);
            return StatusCode(data.Code, data);
        }
        [HttpGet("read/{id}")]
        public async Task<IActionResult> GetTicket([FromRoute] long id)
        {
            var data = await _ticketService.GetTicket(id);
            return StatusCode(data.Code, data);
        }
        [HttpGet("read")]
        public async Task<IActionResult> GetALl()
        {
            var data = await _ticketService.GetAll();
            return StatusCode(data.Code, data);
        }
    }
}
