using System.Collections.Generic;
using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Repositories;

namespace Service.User
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public void Create(Client client)
        {
            _clientRepository.Create(client);
        }

        public void Delete(int id)
        {

            Client client = GetClient(id);
            _clientRepository.Delete(client);
        }

        public Client GetClient(int id)
        {
            return _clientRepository.GetClient(id);
        }

        public List<Client> GetClients()
        {
            return _clientRepository.GetClients();
        }

        public Client Login(string Email, string Password)
        {
            return _clientRepository.Login(Email, Password);
        }

        public void Update(Client client)
        {
            _clientRepository.Update(client);
        }
    }
}
