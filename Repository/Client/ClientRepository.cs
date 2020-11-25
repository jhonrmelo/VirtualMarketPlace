using LinqKit;
using Microsoft.Extensions.Configuration;
using Repository.Database.Generic;
using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Repository.Database;

using X.PagedList;

namespace VirtualMarketPlace.Repositories.Repository
{
    public class ClientRepository : GenericRepository<ClientModel>, IClientRepository
    {
        private VirtualMarketPlaceContext _database;
        private IConfiguration _conf;

        public ClientRepository(VirtualMarketPlaceContext database, IConfiguration configuration) : base(database)
        {
            _database = database;
            _conf = configuration;
        }

        public ClientModel GetClient(int id)
        {
            return _database.Clients.Find(id);
        }

        public List<ClientModel> GetClients()
        {
            return _database.Clients.ToList();
        }

        public IPagedList<ClientModel> GetPagedClients(int index, ExpressionStarter<ClientModel> whereExpression)
        {
            if (whereExpression.IsStarted)
                return _database.Clients.Where(whereExpression).ToPagedList(index, _conf.GetValue<int>("RegPerPage"));

            return _database.Clients.ToPagedList(index, _conf.GetValue<int>("RegPerPage"));
        }

        public ClientModel Login(string Email, string Password)
        {
            return _database.Clients.Where(client => client.Email == Email
                                                  && client.Password == Password)
                                                  .FirstOrDefault();
        }

    }
}
