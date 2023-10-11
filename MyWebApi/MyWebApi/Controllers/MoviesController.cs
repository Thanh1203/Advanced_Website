using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public MoviesController(MyDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> getFlim()
        {
            var ifMovies = await _context.Movies.ToListAsync();
            return Ok(ifMovies);
        }

        [HttpPost]
        public IActionResult createNewFlim(Movies model)
        {
            try
            {
                var flim = new Movies
                {
                    MovieName = model.MovieName,
                    MovieGenre = model.MovieGenre,
                    MovieDuration = model.MovieDuration,
                    MovieOgDate = model.MovieOgDate,
                    MovieImage = model.MovieImage,
                    MovieStatus = model.MovieStatus,
                };
                _context.Add(flim);
                _context.SaveChanges();
                return Ok(flim);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateFlim(int id, Movies model)
        {
            var infoFlim = _context.Movies.SingleOrDefault(item => item.IdMovie == id);
            if (infoFlim != null)
            {
                infoFlim.MovieGenre = model.MovieGenre;
                infoFlim.MovieDuration = model.MovieDuration;
                infoFlim.MovieOgDate = model.MovieOgDate;
                infoFlim.MovieImage = model.MovieImage;
                infoFlim.MovieStatus = model.MovieStatus;
                _context.SaveChanges();
                return Ok(infoFlim);
            }
            else { return NotFound(); }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteFlim(int id)
        {
            var infoFlim = _context.Movies.SingleOrDefault(item => item.IdMovie == id);
            if (infoFlim != null)
            {
                _context.Movies.Remove(infoFlim);
                _context.SaveChanges();
                return Ok("Delete success");
            }
            else { return NotFound(); }
        }
    }
}
