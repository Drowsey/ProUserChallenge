using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProUser.Contracts;
using ProUser.Models;

namespace ProUser.Services
{
    public class ViaCepService : IAddressService
    {
        public async Task<UserAddress> GetAddressByCEPAsync(string cep)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/"))
                {
                    using (HttpContent content = response.Content)
                    {
                        var respostaApi = await content.ReadAsStringAsync();
                        var userAddress = JsonConvert.DeserializeObject<UserAddress>(respostaApi);

                        return userAddress;
                    }
                }
            }
        }
    }
}