using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InforMoviesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public InforMoviesController(MyDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> getFlim()
        {
            var ifMovies = await _context.InfoMovies.ToListAsync();
            return Ok(ifMovies);
        }

        [HttpPost]
        public IActionResult createNewFlim(InfoMovies model)
        {
            try
            {
                var flim = new InfoMovies
                {
                    TenPhim = model.TenPhim,
                    TheLoai = model.TheLoai,
                    ThoiLuong = model.ThoiLuong,
                    KhoiChieu = model.KhoiChieu,
                    ImgName = model.ImgName,
                    StatusFlim = model.StatusFlim,
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
        public IActionResult updateFlim(int id, InfoMovies model)
        {
            var infoFlim = _context.InfoMovies.SingleOrDefault(item => item.IdPhim == id);
            if (infoFlim != null)
            {
                infoFlim.TheLoai = model.TheLoai;
                infoFlim.ThoiLuong = model.ThoiLuong;
                infoFlim.KhoiChieu = model.KhoiChieu;
                infoFlim.ImgName = model.ImgName;
                infoFlim.StatusFlim = model.StatusFlim;
                _context.SaveChanges();
                return Ok(infoFlim);
            }
            else { return NotFound(); }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteFlim(int id)
        {
            var infoFlim = _context.InfoMovies.SingleOrDefault(item => item.IdPhim == id);
            if (infoFlim != null)
            {
                _context.InfoMovies.Remove(infoFlim);
                _context.SaveChanges();
                return Ok("Delete success");
            }
            else { return NotFound(); }
        }
    }
}
