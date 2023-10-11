using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SlideMoviesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public SlideMoviesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getSlideMovies()
        {
            var slMovie = await _context.SlideMovies.ToListAsync();
            return Ok(slMovie);
        }

        [HttpPost]
        public IActionResult createSlideMovies(SlideMovies model)
        {
            try
            {
                var slMovie = new SlideMovies
                {
                    slideName = model.slideName,
                    slideImage = model.slideImage,
                };
                _context.Add(slMovie);
                _context.SaveChanges();
                return Ok(slMovie);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateSlideMovies(int id, SlideMovies model)
        {
            var slMovie = _context.SlideMovies.SingleOrDefault(item => item.IdSlide == id);
            if (slMovie != null)
            {
                slMovie.slideName = model.slideName;
                slMovie.slideImage = model.slideImage;
                _context.SaveChanges();
                return Ok(slMovie);
            }
            else { return NotFound(); }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteSlideMoives(int id)
        {
            var slMovie = _context.SlideMovies.SingleOrDefault(item => item.IdSlide == id);
            if (slMovie != null)
            {
                _context.SlideMovies.Remove(slMovie);
                _context.SaveChanges();
                return Ok("Delete success");
            }
            else { return NotFound(); }
        }
    }
}