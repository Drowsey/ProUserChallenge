using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProUser.Models
{
    public class User
    {
        [BsonId]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string PrimeiroNome { get; set; }
        public string ÚltimoNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public UserAddress Address { get; set; }
    }
}