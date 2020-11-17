using LinqKit;

using System.Collections.Generic;

using VirtualMarketPlace.Domain.Models;
using VirtualMarketPlace.Repositories;

using X.PagedList;

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

        public IPagedList<ClientModel> GetPagedClients(int? page, string searchName, string searchEmail)
        {
            var predicate = PredicateBuilder.New<ClientModel>();

            //Filters
            if (!string.IsNullOrEmpty(searchName))
                predicate.And(x => x.Name.ToUpper().Contains(searchName.Trim().ToUpper()));

            if (!string.IsNullOrEmpty(searchEmail))
                predicate.And(x => x.Email.ToUpper().Contains(searchEmail.Trim().ToUpper()));

            int indexPage = page ?? 1;

            return _clientRepository.GetPagedClients(indexPage, predicate);
        }

        public ClientModel Login(string Email, string Password)
        {
            return _clientRepository.Login(Email, Password);
        }

        public void Update(ClientModel client)
        {
            _clientRepository.Update(client);
        }
        public void ChangeStatus(int id)
        {
            var clientToChange = GetClient(id);
            clientToChange.Status = !clientToChange.Status;
            _clientRepository.Update(clientToChange);
        }
    }
}
