using VirtualMarketPlace.Domain.Models;

namespace Service.Login.Clients
{
    public interface IClientLoginService
    {
        void Login(ClientModel client);
        ClientModel GetClient();
        void Logout();
    }
}
