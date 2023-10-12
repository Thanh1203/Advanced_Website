using BeApiCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD.Controllers
{
    [Route("/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly MyDbContext _context;
        IWebHostEnvironment _environment;

        public MoviesController(MyDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var ifMovies = await _context.Movies.ToListAsync();
            return Ok(ifMovies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoives([FromForm] MoviesFile movie)
        {
            try
            {
                var rootAddress = _environment.WebRootPath;
                var newMovie = new Movies
                {
                    MovieName = movie.MovieName,
                    MovieGenre = movie.MovieGenre,
                    MovieDuration = movie.MovieDuration,
                    MovieOgDate = movie.MovieOgDate,
                    MovieStatus = movie.MovieStatus,
                };
                if (movie.MovieImgfile != null && movie.MovieImgfile?.Length > 0)
                {
                    var path = Path.Combine(rootAddress, "Images", movie.MovieImgfile.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await movie.MovieImgfile.CopyToAsync(stream);
                    }
                    newMovie.MovieImage = "http://localhost:5163/Images/" + movie.MovieImgfile.FileName;
                }
                else
                {
                    newMovie.MovieName = "";
                }
                _context.Add(newMovie);
                _context.SaveChanges();
                return Ok("Create successful!");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFlim([FromForm] int id, MoviesFile movie)
        {
            try
            {
                var upMovie = _context.Movies.SingleOrDefault(item => item.IdMovie == id);
                if (upMovie != null)
                {
                    if (!string.IsNullOrEmpty(movie.MovieGenre))
                        upMovie.MovieGenre = movie.MovieGenre;
                    if (movie.MovieDuration.HasValue)
                        upMovie.MovieDuration = movie.MovieDuration;
                    if (movie.MovieOgDate.HasValue)
                        upMovie.MovieOgDate = movie.MovieOgDate;
                    if (movie.MovieStatus.HasValue)
                        upMovie.MovieStatus = movie.MovieStatus;

                    if (movie.MovieImgfile != null && movie.MovieImgfile.Length > 0)
                    {
                        var rootAddress = _environment.WebRootPath;
                        var path = Path.Combine(rootAddress, "Images", movie.MovieImgfile.FileName);
                        using (var stream = System.IO.File.Create(path))
                        {
                            movie.MovieImgfile.CopyToAsync(stream);
                        }
                        upMovie.MovieImage = movie.MovieImgfile.FileName; ;
                    }
                    _context.SaveChanges();
                    return Ok(upMovie);
                }
                else { return NotFound(); }
            }
            catch { return BadRequest(); }
        }
    }
}
