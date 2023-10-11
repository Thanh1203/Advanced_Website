using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public EventsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> getEvent()
        {
            var ifEvent = await _context.EventsData.ToListAsync();
            return Ok(ifEvent);
        }
        [HttpPost]
        public IActionResult createEvent(EventsData model)
        {
            try
            {
                var ifEvent = new EventsData
                {
                    IdEvent = model.IdEvent,
                    Eventname = model.Eventname,
                    Eventimage = model.Eventimage,
                    Eventlink = model.Eventlink,
                };
                _context.Add(ifEvent);
                _context.SaveChanges();
                return Ok(ifEvent);
            }
            catch
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult updateEvent(int id, EventsData model)
        {
            var ifEvent = _context.EventsData.SingleOrDefault(item => item.IdEvent == id);
            if (ifEvent != null)
            {
                ifEvent.Eventname = model.Eventname;
                ifEvent.Eventimage = model.Eventimage;
                ifEvent.Eventlink = model.Eventlink;
                _context.SaveChanges();
                return Ok(ifEvent);
            }
            else { return NotFound(); }
        }
        [HttpDelete("{id}")]
        public IActionResult deleteEvent(int id)
        {
            var ifEvent = _context.EventsData.SingleOrDefault(item => item.IdEvent == id);
            if (ifEvent != null)
            {
                _context.EventsData.Remove(ifEvent);
                _context.SaveChanges();
                return Ok("Delete success");
            }
            else
            {
                return NotFound();
            }
        }
    }
}