using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ShowTimesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ShowTimesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getShowTimes(int id)
        {
            var stimes = await _context.ShowTimes.Where(item => item.IdPhim == id).ToListAsync();
            return Ok(stimes);
        }

        [HttpPost]
        public IActionResult createNewShowTime(ShowTimes model)
        {
            try
            {
                var stimes = new ShowTimes
                {
                    IdPhim = model.IdPhim,
                    MovieDate = model.MovieDate,
                    TimeSlot = model.TimeSlot,
                    NofTickets = model.NofTickets,
                };
                _context.Add(stimes);
                _context.SaveChanges();
                return Ok(stimes);
            }
            catch
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateShowTime(int id, ShowTimes model)
        {
            var stimes = _context.ShowTimes.SingleOrDefault(item => item.IdPhim == id);
            if (stimes != null)
            {
                stimes.MovieDate = model.MovieDate;
                stimes.TimeSlot = model.TimeSlot;
                stimes.NofTickets = model.NofTickets;
                _context.SaveChanges();
                return Ok(stimes);
            }
            else { return NotFound(); }
        }
    }
}