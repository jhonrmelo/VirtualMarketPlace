using System.Collections.Generic;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Models;

namespace VirtualMarketPlace.Repositories
{
    public interface IClientRepository
    {
        ClientModel Login(string Email, string Password);
        void Create(ClientModel client);
        void Update(ClientModel client);
        void Delete(ClientModel client);
        ClientModel GetClient(int id);
        List<ClientModel> GetClients();
    }
}
