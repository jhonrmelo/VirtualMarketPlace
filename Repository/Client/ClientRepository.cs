using Repository.Database.Generic;
using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Repository.Database;

namespace VirtualMarketPlace.Repositories.Repository
{
    public class ClientRepository : GenericRepository<ClientModel>, IClientRepository
    {
        private VirtualMarketPlaceContext _database;

        public ClientRepository(VirtualMarketPlaceContext database) : base(database)
        {
            _database = database;
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

    }
}
