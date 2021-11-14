using ProUser.Contracts;

namespace ProUser.Models
{
    public class ProUserDatabaseSettings : IProUserDatabaseSettings
    {
        public string UsersCollectionName { get ; set;}
        public string ConnectionString { get ; set;}
        public string DatabaseName { get ; set;}
    }
}