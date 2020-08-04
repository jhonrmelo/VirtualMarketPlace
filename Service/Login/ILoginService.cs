using VirtualMarketPlace.Domain.Models;

namespace Service.Login
{
    public interface ILoginService
    {
        void Login(Client client);
        Client GetClient();
        void Logout();
    }
}
