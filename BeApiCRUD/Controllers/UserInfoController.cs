using BeApiCRUD.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeApiCRUD.Controllers
{
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] UserInfoFile userInfoFile, int id)
        {
            var updateUser = _context.UserInfos.SingleOrDefault(item => item.IdUser == id);
            var rootAddress = _enviroment.WebRootPath;
            if (updateUser == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userInfoFile.UserFullName != null)
            {
                updateUser.UserFullName = userInfoFile.UserFullName;
            }
            if (userInfoFile.UserSex != null)
            {
                updateUser.UserSex = userInfoFile.UserSex;
            }
            if (userInfoFile.UserBirth != null)
            {
                updateUser.UserBirth = userInfoFile.UserBirth;
            }
            if (userInfoFile.UserPhonenumber != null)
            {
                updateUser.UserPhonenumber = userInfoFile.UserPhonenumber;
            }
            if (userInfoFile.UserAvatar != null)
            {
                var path = Path.Combine(rootAddress, "AvatarUser", userInfoFile.UserAvatar.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await userInfoFile.UserAvatar.CopyToAsync(stream);
                }
                updateUser.UserImage = "http://localhost:5163/Images/" + userInfoFile.UserAvatar.FileName;
            }

            _context.SaveChanges();
            return Ok(updateUser);
        }
    }
}
