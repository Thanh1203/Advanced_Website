using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BeApiCRUD.Auth;
using BeApiCRUD.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BeApiCRUD.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            MyDbContext context,
            IConfiguration configuration
        )
        {
            _context = context;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromForm] AccUser model)
        {
            var user = await _context.AccUsers.SingleOrDefaultAsync(item => item.Username == model.Username && item.Password == model.Password);
            if (user != null) {
                var token = GetToken(user);
               return Ok(new {
                   token = new JwtSecurityTokenHandler().WriteToken(token),
                   expiration = token?.ValidTo
               });
            }
            return Unauthorized();
        }

        private JwtSecurityToken? GetToken(AccUser user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username))
            {
                return null;
            }
            var secretkey = _configuration["JWT:SecretKey"];
            if (secretkey == null )
            {
                return new JwtSecurityToken();
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
                );

            return token;
        }
    }
}

