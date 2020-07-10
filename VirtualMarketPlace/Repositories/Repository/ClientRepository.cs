using System;
using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Database;
using VirtualMarketPlace.Models;

namespace VirtualMarketPlace.Repositories.Repository
{
    public class ClientRepository : IClientRepository
    {
        private VirtualMarketPlaceContext _database;

        public ClientRepository(VirtualMarketPlaceContext database)
        {
            _database = database;
        }
        public void Create(Client client)
        {
            _database.Add(client);
            _database.SaveChanges();
        }

        public void Delete(int id)
        {
            Client client = GetClient(id);

            _database.Remove(client);
            _database.SaveChanges();
        }

        public Client GetClient(int id)
        {
            return _database.Clients.Find(id);
        }

        public List<Client> GetClients()
        {
            return _database.Clients.ToList();
        }

        public Client Login(string Email, string Password)
        {
            return _database.Clients.Where(client => client.Email == Email
                                                  && client.Password == Password)
                                                  .FirstOrDefault();
        }

        public void Update(Client client)
        {
            _database.Update(client);
            _database.SaveChanges();
        }
    }
}
