using System.Collections.Generic;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Models;

namespace VirtualMarketPlace.Repositories
{
    public interface IClientRepository
    {
        Client Login(string Email, string Password);
        void Create(Client client);
        void Update(Client client);
        void Delete(Client client);
        Client GetClient(int id);
        List<Client> GetClients();
    }
}
