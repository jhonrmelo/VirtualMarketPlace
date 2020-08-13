using Repository.Database.Generic;
using System.Collections.Generic;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Models;

namespace VirtualMarketPlace.Repositories
{
    public interface IClientRepository : IGenericRepository<ClientModel>
    {
        ClientModel Login(string Email, string Password);
        ClientModel GetClient(int id);
        List<ClientModel> GetClients();
    }
}
