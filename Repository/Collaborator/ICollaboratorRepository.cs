using System.Collections.Generic;
using CollaboratorModel = Domain.Models.CollaboratorModel;

namespace Repository.Collaborator
{
    public interface ICollaboratorRepository
    {
        CollaboratorModel Login(string Email, string Password);
        void Create(CollaboratorModel collaborator);
        void Update(CollaboratorModel collaborator);
        void Delete(CollaboratorModel collaborator);
        CollaboratorModel GetCollaborator(int id);
        List<CollaboratorModel> GetCollaborators();
    }
}
