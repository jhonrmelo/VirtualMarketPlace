using Newtonsoft.Json;
using Service.Session;
using VirtualMarketPlace.Domain.Models;

namespace Service.Login
{
    public class LoginService : ILoginService
    {
        private string Key = "Login.Client";
        private SessionHelper _session;
        public LoginService(SessionHelper session)
        {
            _session = session;
        }

        public void Login(Client client)
        {
            string jsonClient = JsonConvert.SerializeObject(client);
            _session.Put(Key, jsonClient);
        }
        public Client GetClient()
        {
            if (_session.HasKey(Key))
                return JsonConvert.DeserializeObject<Client>(_session.Get(Key));

            return null;
        }

        public void Logout()
        {
            _session.RemoveAll(Key);
        }
    }
}
