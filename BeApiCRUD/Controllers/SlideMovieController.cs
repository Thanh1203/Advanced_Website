using BeApiCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class SlideMovieController : ControllerBase
    {
        private readonly MyDbContext _context;
        IWebHostEnvironment _enviroment;
        public SlideMovieController(MyDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _enviroment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetSlide()
        {
            var ifSlideMovie = await _context.SlideMovies.ToListAsync();
            return Ok(ifSlideMovie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlide([FromForm] SlideMovieFile model)
        {
            try
            {
                var rootAddress = _enviroment.WebRootPath;
                var newSlide = new SlideMovie
                {
                    SlideName = model.SlideName
                };
                if (model.SlideImgFile != null)
                {
                    var path = Path.Combine(rootAddress, "Slides", model.SlideImgFile.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await model.SlideImgFile.CopyToAsync(stream);
                    }
                    newSlide.SlideImage = "http://localhost:5163/Slides/" + model.SlideImgFile.FileName;
                }
                else { newSlide.SlideImage = ""; }
                _context.Add(newSlide);
                _context.SaveChanges();
                return Ok("Create successful");
            }
            catch { return BadRequest(); }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateSlide([FromForm] SlideMovieFile model, int id)
        {
            var updateSlide = _context.SlideMovies.SingleOrDefault(item => item.IdSlide == id);
            var rootAddress = _enviroment.WebRootPath;

            if (updateSlide == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.SlideName != null)
            {
                updateSlide.SlideName = model.SlideName;
            }

            if (model.SlideImgFile != null)
            {
                var path = Path.Combine(rootAddress, "Slides", model.SlideImgFile.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await model.SlideImgFile.CopyToAsync(stream);
                }
                updateSlide.SlideImage = "http://localhost:5163/Slides/" + model.SlideImgFile.FileName;
            }
            _context.SaveChanges();
            return Ok(updateSlide);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlide(int id)
        {
            var deSlide = _context.SlideMovies.SingleOrDefault(item => item.IdSlide == id);
            if (deSlide != null)
            {
                if (deSlide.SlideImage != null && deSlide.SlideImage != "")
                {
                    string strName = deSlide.SlideImage;
                    string[] strArray = strName.Split('/');
                    string? lastElement = strArray?.LastOrDefault();
                    var path = Path.Combine(_enviroment.WebRootPath, "Events", lastElement ?? "default-value");
                    System.IO.File.Delete(path);
                }
                _context.SlideMovies.Remove(deSlide);
                await _context.SaveChangesAsync();
                return Ok(deSlide);

            }
            else { return NotFound(); }
        }
    }
}