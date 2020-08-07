using CollaboratorModel = Domain.Models.CollaboratorModel;
namespace Service.Login.Collaborators
{
    public interface ICollaboratorLoginService
    {
        void Login(CollaboratorModel collaborator);
        CollaboratorModel GetCollaborator();
        void Logout();
    }
}
