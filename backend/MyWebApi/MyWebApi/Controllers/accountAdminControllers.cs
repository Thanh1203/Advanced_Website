using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("/Login-Admin")]
    public class accountAdminControllers : ControllerBase
    {
        private readonly MyDbContext _context;
        public accountAdminControllers(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accAdmins = await _context.accountAdmins.ToListAsync();
            return Ok(accAdmins);
        }
    }
}
