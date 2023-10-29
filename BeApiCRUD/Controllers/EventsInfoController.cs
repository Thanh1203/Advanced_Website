using BeApiCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class EventsInfoController : ControllerBase
    {
        private readonly MyDbContext _context;
        IWebHostEnvironment _enviroment;
        public EventsInfoController(MyDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _enviroment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvent()
        {
            var ifEvents = await _context.EventsInfos.ToListAsync();
            return Ok(ifEvents);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromForm] EventsInfoFile model)
        {
            try
            {
                var rootAddress = _enviroment.WebRootPath;
                var newEvent = new EventsInfo
                {
                    Eventname = model.Eventname,
                    Eventlink = model.Eventlink
                };
                if (model.EventImgFile != null)
                {
                    var path = Path.Combine(rootAddress, "Events", model.EventImgFile.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await model.EventImgFile.CopyToAsync(stream);
                    }
                    newEvent.Eventimage = "http://localhost:5163/Events/" + model.EventImgFile.FileName;
                }
                else { newEvent.Eventimage = ""; }
                _context.Add(newEvent);
                _context.SaveChanges();
                return Ok("Create successful");
            }
            catch { return BadRequest(); }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEvent([FromForm] EventsInfoFile model, int id)
        {
            var updateEvent = _context.EventsInfos.SingleOrDefault(item => item.IdEvent == id);
            var rootAddress = _enviroment.WebRootPath;

            if (updateEvent == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Eventname != null)
            {
                updateEvent.Eventname = model.Eventname;
            }

            if (model.Eventlink != null)
            {
                updateEvent.Eventlink = model.Eventlink;
            }

            if (model.EventImgFile != null && model.EventImgFile.Length > 0)
            {
                var path = Path.Combine(rootAddress, "Events", model.EventImgFile.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await model.EventImgFile.CopyToAsync(stream);
                }
                updateEvent.Eventimage = "http://localhost: 5163/Events/" + model.EventImgFile.FileName;
            }
            _context.SaveChanges();
            return Ok(updateEvent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var deEvent = _context.EventsInfos.SingleOrDefault(item => item.IdEvent == id);
            if (deEvent != null)
            {
                if (deEvent.Eventimage != null && deEvent.Eventimage != "")
                {
                    string strName = deEvent.Eventimage;
                    string[] strArray = strName.Split('/');
                    string? lastElement = strArray?.LastOrDefault();
                    var path = Path.Combine(_enviroment.WebRootPath, "Events", lastElement ?? "default-value");
                    System.IO.File.Delete(path);
                }
                _context.EventsInfos.Remove(deEvent);
                await _context.SaveChangesAsync();
                return Ok(deEvent);
            }
            else { return NotFound(); }
        }
    }
}