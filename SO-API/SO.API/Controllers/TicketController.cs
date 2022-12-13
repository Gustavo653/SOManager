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
        public async Task<IActionResult> CreateTicket(TicketDTO ticketDTO)
        {
            var userDTO = await _accountService.GetUserByUserNameAsync(User.GetUserName());
            var data = await _ticketService.CreateTicket(userDTO,ticketDTO);
            return StatusCode(data.Code, data);
        }
    }
}
