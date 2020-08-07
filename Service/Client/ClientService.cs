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
        public void Create(ClientModel client)
        {
            _clientRepository.Create(client);
        }

        public void Delete(int id)
        {

            ClientModel client = GetClient(id);
            _clientRepository.Delete(client);
        }

        public ClientModel GetClient(int id)
        {
            return _clientRepository.GetClient(id);
        }

        public List<ClientModel> GetClients()
        {
            return _clientRepository.GetClients();
        }

        public ClientModel Login(string Email, string Password)
        {
            return _clientRepository.Login(Email, Password);
        }

        public void Update(ClientModel client)
        {
            _clientRepository.Update(client);
        }
    }
}
