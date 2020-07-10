using System.Collections.Generic;
using VirtualMarketPlace.Models;

namespace VirtualMarketPlace.Repositories
{
    interface IClientRepository
    {
        Client Login(string Email, string Password);
        void Create(Client client);
        void Update(Client client);
        void Delete(int id);
        Client GetClient(int id);
        List<Client> GetClients();
    }
}
