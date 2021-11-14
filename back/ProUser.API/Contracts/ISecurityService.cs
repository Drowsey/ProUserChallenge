using ProUser.Models;

namespace ProUser.Contracts
{
    public interface ISecurityService
    {
        public string HashPassword(string password);
        public bool VerifyPassword(Login login);

    }
}