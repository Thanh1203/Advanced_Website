
using BeApiCRUD.Model;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class ShowtimeController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ShowtimeController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/{str}")]
        public async Task<IActionResult> GetShowtimes(int id, string str)
        {
            var ifShowtimes = await _context.Showtimes
            .Where(item => item.IdMovie == id)
            .Where(item => item.Moviedate == str)
            .ToListAsync();
            return Ok(ifShowtimes);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShowTime([FromForm] Showtime model)
        {
            try
            {
                var newShowtime = new Showtime
                {
                    IdMovie = model.IdMovie,
                    Moviedate = model.Moviedate,
                    Timeslot = model.Timeslot,
                    NofTickets = model.NofTickets,
                    NofSeat = model.NofTickets
                };
                _context.Add(newShowtime);
                await _context.SaveChangesAsync();
                return Ok("Crete successfull");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}/{index}")]
        public async Task<IActionResult> UpdateShowtime([FromForm] Showtime model, int id, int index)
        {
            try
            {
                var updateShowtime = _context.Showtimes
                .Where(item => item.IdMovie == id)
                .Where(item => item.Row_number == index)
                .SingleOrDefault();
                if (updateShowtime == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (model.Moviedate != null)
                {
                    updateShowtime.Moviedate = model.Moviedate;
                }

                if (model.Timeslot != null)
                {
                    updateShowtime.Timeslot = model.Timeslot;
                }

                if (model.NofTickets != null)
                {
                    updateShowtime.NofTickets = model.NofTickets;
                }
                if (model.NofSeat != null)
                {
                    updateShowtime.NofSeat = model.NofSeat;
                }
                await _context.SaveChangesAsync();
                return Ok(updateShowtime);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}/{index}")]
        public async Task<IActionResult> DeleteShowtime(int id, int index)
        {
            var deShowtime = _context.Showtimes
            .Where(item => item.Row_number == index)
            .Where(item => item.IdMovie == id)
            .SingleOrDefault();
            if (deShowtime != null)
            {
                _context.Showtimes.Remove(deShowtime);
                await _context.SaveChangesAsync();
                return Ok(deShowtime);
            }
            else { return NotFound(); }
        }
    }
}