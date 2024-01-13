using BeApiCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class TicketController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TicketController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var inforTicket = await _context.Tickets
            .Where(item => item.IdTicket == id)
            .ToListAsync();
            return Ok(inforTicket);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromForm] Ticket model)
        {
            try
            {
                var newTicket = new Ticket
                {
                    IdMovie = model.IdMovie,
                    IdUser = model.IdUser,
                    SeatPosition = model.SeatPosition,
                    MovieDate = model.MovieDate,
                    Timeslot = model.Timeslot,
                };
                _context.Add(newTicket);
                await _context.SaveChangesAsync();
                return Ok("Crete successfull");
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}