using ProUser.Contracts;
using ProUser.Models;

namespace ProUser.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly UserService _userService;
        public SecurityService(UserService userService)
        {
            _userService = userService;
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(Login login)
        {
            return BCrypt.Net.BCrypt.Verify(login.Password, _userService.GetHashPassword(login.Username));
        }
    }
}