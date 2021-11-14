using Microsoft.AspNetCore.Mvc;
using ProUser.Contracts;
using ProUser.Models;
using ProUser.Services;

namespace ProUser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserService _userService;

        public LoginController(ITokenService tokenService, UserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody] Login model)
        {
            var user = _userService.GetUser(model.Username.Trim());
            if (user == null) NotFound("Usuário ou senha inválidos.");

            var token = _tokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
    }
}