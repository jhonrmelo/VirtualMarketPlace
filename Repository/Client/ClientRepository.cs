using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Repository.Database;

namespace VirtualMarketPlace.Repositories.Repository
{
    public class ClientRepository : IClientRepository
    {
        private VirtualMarketPlaceContext _database;

        public ClientRepository(VirtualMarketPlaceContext database)
        {
            _database = database;
        }
        public void Create(ClientModel client)
        {
            _database.Add(client);
            _database.SaveChanges();
        }

        public void Delete(ClientModel client)
        {
            _database.Remove(client);
            _database.SaveChanges();
        }

        public ClientModel GetClient(int id)
        {
            return _database.Clients.Find(id);
        }

        public List<ClientModel> GetClients()
        {
            return _database.Clients.ToList();
        }

        public ClientModel Login(string Email, string Password)
        {
            return _database.Clients.Where(client => client.Email == Email
                                                  && client.Password == Password)
                                                  .FirstOrDefault();
        }

        public void Update(ClientModel client)
        {
            _database.Update(client);
            _database.SaveChanges();
        }
    }
}
