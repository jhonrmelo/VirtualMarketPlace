using Repository.Database.Generic;
using System.Collections.Generic;
using CollaboratorModel = Domain.Models.CollaboratorModel;

namespace Repository.Collaborator
{
    public interface ICollaboratorRepository : IGenericRepository<CollaboratorModel>
    {
        CollaboratorModel Login(string Email, string Password);
        CollaboratorModel GetCollaborator(int id);
        List<CollaboratorModel> GetCollaborators();
    }
}
