using BeApiCRUD.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]

    public class UserInfoController : ControllerBase
    {
        private readonly MyDbContext _context;
        IWebHostEnvironment _enviroment;
        public UserInfoController(MyDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _enviroment = environment;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoUser(int id)
        {
            var ifUser = await _context.UserInfos.SingleOrDefaultAsync(item => item.IdUser == id);
            return Ok(ifUser);
        }
    }
}
