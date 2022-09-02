using Newtonsoft.Json;

using Service.Session;

using VirtualMarketPlace.Domain.Models;

namespace Service.Login.Clients
{
    public class ClientLoginService : IClientLoginService
    {
        private readonly string _key = "Login.Client";
        private SessionHelper _session;

        public ClientLoginService(SessionHelper session)
        {
            _session = session;
        }

        public void Login(ClientModel client)
        {
            string jsonClient = JsonConvert.SerializeObject(client);
            _session.Put(_key, jsonClient);
        }

        public ClientModel GetClient()
        {
            if (_session.HasKey(_key))
                return JsonConvert.DeserializeObject<ClientModel>(_session.Get(_key));

            return null;
        }

        public void Logout()
        {
            _session.RemoveAll(_key);
        }
    }
}