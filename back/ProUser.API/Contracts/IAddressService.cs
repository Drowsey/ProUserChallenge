using System.Threading.Tasks;
using ProUser.Models;

namespace ProUser.Contracts
{
    public interface IAddressService
    {
        public Task<UserAddress> GetAddressByCEPAsync(string cep);
    }
}