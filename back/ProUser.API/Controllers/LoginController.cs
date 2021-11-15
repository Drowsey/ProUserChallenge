using Microsoft.AspNetCore.Mvc;
using ProUser.Contracts;
using ProUser.Models;
using ProUser.Services;

namespace ProUser.Controllers
{
    [ApiController]
    [Route("auth")]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly UserService _userService;
        private readonly ISecurityService _securityService;

        public LoginController(ITokenService tokenService, UserService userService, ISecurityService securityService)
        {
            _tokenService = tokenService;
            _userService = userService;
            _securityService = securityService;
        }

        [HttpPost, Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] Login model)
        {
            var user = _userService.GetUser(model.Username.Trim());
            if (user == null) return NotFound("Usuário ou senha inválidos.");

            var verify = _securityService.VerifyPassword(model);
            if (!verify) return NotFound("Usuário ou senha inválidos.");

            var token = _tokenService.GenerateToken(user);

            user.Password = "";

            return new {
                user = user,
                token = token
            };
        }
    }
}