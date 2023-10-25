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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoviesWithId(int id)
        {
            var ifMovies = await _context.Movies.SingleOrDefaultAsync(item => item.IdMovie == id);
            return Ok(ifMovies);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMoive([FromForm] MoviesFile movie)
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
                    MovieContent = movie.MovieContent
                };
                if (movie.MovieImgfile != null)
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
                    newMovie.MovieImage = "";
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMovie([FromForm] MoviesFile movie, int id)
        {
            var updateMovie = _context.Movies.SingleOrDefault(item => item.IdMovie == id);
            var rootAddress = _environment.WebRootPath;

            if (updateMovie == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (movie.MovieName != null)
            {
                updateMovie.MovieName = movie.MovieName;
            }

            if (movie.MovieGenre != null)
            {
                updateMovie.MovieGenre = movie.MovieGenre;
            }

            if (movie.MovieDuration != null)
            {
                updateMovie.MovieDuration = movie.MovieDuration;
            }

            if (movie.MovieOgDate != null)
            {
                updateMovie.MovieOgDate = movie.MovieOgDate;
            }

            if (movie.MovieStatus != null)
            {
                updateMovie.MovieStatus = movie.MovieStatus;
            }

            if (movie.MovieContent != null)
            {
                updateMovie.MovieContent = movie.MovieContent;
            }

            if (movie.MovieImgfile != null && movie.MovieImgfile.Length > 0)
            {
                var path = Path.Combine(rootAddress, "Images", movie.MovieImgfile.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await movie.MovieImgfile.CopyToAsync(stream);
                }
                updateMovie.MovieImage = "http://localhost:5163/Images/" + movie.MovieImgfile.FileName;
            }

            _context.SaveChanges();
            return Ok(updateMovie);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var deMovie = _context.Movies.SingleOrDefault(item => item.IdMovie == id);
            if (deMovie != null)
            {
                if (deMovie.MovieImage != null && deMovie.MovieImage != "")
                {
                    string strName = deMovie.MovieImage;
                    string[] strArray = strName.Split('/');
                    string? lastElement = strArray?.LastOrDefault();
                    var path = Path.Combine(_environment.WebRootPath, "Images", lastElement ?? "default-value");
                    System.IO.File.Delete(path);
                }
                _context.Movies.Remove(deMovie);
                await _context.SaveChangesAsync();
                return Ok(deMovie);
            }
            else { return NotFound(); }
        }
    }
}
