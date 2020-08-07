using System.Collections.Generic;
using CollaboratorModel = Domain.Models.CollaboratorModel;

namespace Service.Collaborator
{
    public interface ICollaboratorService
    {
        CollaboratorModel Login(string Email, string Password);
        void Create(CollaboratorModel collaborator);
        void Update(CollaboratorModel collaborator);
        void Delete(int id);
        CollaboratorModel GetCollaborator(int id);
        List<CollaboratorModel> GetCollaborators();
    }
}
