using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;

namespace MyWebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AccountUsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        public AccountUsersController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAccountUser()
        {
            var accUsers = await _context.AccountUsers.ToListAsync();
            return Ok(accUsers);
        }

        [HttpPost]
        public IActionResult createAccUser(AccountUsers model)
        {
            try
            {
                var accUsers = new AccountUsers
                {
                    EmailUser = model.EmailUser,
                    Username = model.Username,
                    Password = model.Password
                };
                _context.Add(accUsers);
                _context.SaveChanges();
                return Ok(accUsers);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateAccUser(int id, AccountUsers model)
        {
            var accUsers = _context.AccountUsers.SingleOrDefault(item => item.IdUser == id);
            if (accUsers != null)
            {
                accUsers.EmailUser = model.EmailUser;
                accUsers.Password = model.Password;
                _context.SaveChanges();
                return Ok(accUsers);
            }
            else { return NotFound(); }
        }
    }
}