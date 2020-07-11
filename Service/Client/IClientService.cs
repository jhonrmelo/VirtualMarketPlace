using System.Collections.Generic;
using VirtualMarketPlace.Domain.Models;

namespace Service.User
{
    public interface IClientService
    {
        Client Login(string Email, string Password);
        void Create(Client client);
        void Update(Client client);
        void Delete(int id);
        Client GetClient(int id);
        List<Client> GetClients();
    }
}
