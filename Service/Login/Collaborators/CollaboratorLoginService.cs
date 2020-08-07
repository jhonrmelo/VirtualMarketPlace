using Newtonsoft.Json;
using Service.Session;
using CollaboratorModel = Domain.Models.CollaboratorModel;
namespace Service.Login.Collaborators
{
    public class CollaboratorLoginService : ICollaboratorLoginService
    {
        private readonly string _key = "Login.Client";
        private SessionHelper _session;
        public CollaboratorLoginService(SessionHelper session)
        {
            _session = session;
        }

        public void Login(CollaboratorModel collaborator)
        {
            string jsonCollaborator = JsonConvert.SerializeObject(collaborator);
            _session.Put(_key, jsonCollaborator);
        }
        public CollaboratorModel GetCollaborator()
        {
            if (_session.HasKey(_key))
                return JsonConvert.DeserializeObject<CollaboratorModel>(_session.Get(_key));

            return null;
        }

        public void Logout()
        {
            _session.RemoveAll(_key);
        }
    }
}
