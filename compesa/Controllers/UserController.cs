using compesa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace compesa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UserController(UserContext userContext)
        {
            this._userContext = userContext;
        }

        [HttpGet("/getUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var result = await _userContext.Users.Select(
                s => new User
                {
                    Id = s.Id,
                    Name = s.Name,
                    Email = s.Email,
                    Password = s.Password,
                    Login = s.Login,
                }
            ).ToListAsync();

            if (result.Count < 0 ) 
            { 
                return NotFound();
            } else
            {
                return result;
            }
        }

        [HttpPost("/insertUser")]
        public async Task<HttpStatusCode> InsertUser(User _user)
        {
            var newUser = new User()
            {
                Id = _user.Id,
                Name = _user.Name,
                Email = _user.Email,
                Password = _user.Password,
                Login = _user.Login,
            };

            _userContext.Users.Add(newUser);
            await _userContext.SaveChangesAsync();

            return HttpStatusCode.OK;
        }
    }
}
