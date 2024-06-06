using compesa.Models;
using compesa.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace compesa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public UserController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet("login")]
        public IActionResult getLogin(string UserNick, string UserPass)
        {
            var result = _dataContext.Usuario.FromSqlRaw(Configuration.SearchUser(UserNick)).ToList();

            if(result.Count < 1)
            {
                return NotFound(new { msg = "Usuário não foi encontrado!" });
            } else
            {
                var user = result[0];

                if(user != null)
                {
                    if(user.Senha != UserPass)
                    {
                        return Unauthorized(new { msg = "Senha incorreta"  });
                    } 

                    var permissions = _dataContext.Permissions.FromSqlRaw(Configuration.GetPermissions(user.ID_Usuario)).ToList();

                    List<string> permissionList = new();

                    foreach (var permission in permissions)
                    {
                        permissionList.Add(permission.Nome);
                    }

                    UserReturn userReturn = new()
                    {
                        User_Id = user.ID_Usuario,
                        name = user.Nome,
                        Permissions = permissionList
                    };

                    if(userReturn != null)
                    {
                        string token = JWT.CreateToken(userReturn);
                        return Ok(new TokenDTO { Token = token });
                    }
                }
            }

            return BadRequest();
            
        }

        /*[HttpGet("login")]
        public IActionResult Get(int UserId, string UserPass)
        {
            var result = _dataContext.UserTestes.FromSqlRaw(Configuration.SearchUser(UserId)).ToList();

            if(result.Count < 1)
            {
                return NotFound(new {msg = "Usuário não foi encontrado!"});
            } else
            {
                var user = result.FirstOrDefault();


                if(user != null)
                {
                    if(user.Password != UserPass)
                    {
                        return Unauthorized(new { msg = "Senha incorreta" });
                    }
                    var permissions = _dataContext.Permissions.FromSqlRaw(Configuration.GetPermissions(UserId)).ToList();
                    List<string> permissionList = [];
                    permissions.ForEach(permission =>
                    {
                        permissionList.Add(permission.Name);
                    });

                    User newUserData = new()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        PermissionList = permissionList
                    };


                    if (user != null)
                    {
                        var token = JWT.CreateToken(newUserData);
                        return Ok(new TokenDTO { Token = token });
                    }
                    else
                    {
                        return NotFound(new { msg = "Usuário não foi encontrado!" });
                    }
                } else
                {
                    return NotFound(new { msg = "Usuário não foi encontrado!" });
                }
            }

        }*/
    }
}
