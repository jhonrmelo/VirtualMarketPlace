using System.Collections.Generic;

using VirtualMarketPlace.Domain.Models;

using X.PagedList;

namespace Service.User
{
    public interface IClientService
    {
        ClientModel Login(string Email, string Password);
        void Create(ClientModel client);
        void Update(ClientModel client);
        void Delete(int id);
        ClientModel GetClient(int id);
        List<ClientModel> GetClients();
        IPagedList<ClientModel> GetPagedClients(int? page, string searchName, string searchEmail);
        void ChangeStatus(int id);
    }
}
