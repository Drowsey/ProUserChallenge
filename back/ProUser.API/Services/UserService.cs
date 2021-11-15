using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using ProUser.Contracts;
using ProUser.Models;

namespace ProUser.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(IProUserDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> GetUser(){
            var users = _users.Find(x => true).ToList();
            return users;
        }

        public User GetUser(string username){
            return _users.Find(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string username, User user){
            _users.ReplaceOne(x => x.Username.ToLower() == username.ToLower(), user);
            
        }


        public void Delete(string username){
            _users.DeleteOne(x => x.Username.ToLower() == username.ToLower());
        }

        public bool IsEmailUsed(string email){
            var user = _users.Find(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();

            return (user == null);
        }

        public string GetPassword(string username){

            var user =  _users.Find(x=>x.Username.ToLower() == username.ToLower()).FirstOrDefault();

            return user.Password;
        }
    }
}