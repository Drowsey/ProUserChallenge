using ProUser.Models;

namespace ProUser.Contracts
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}