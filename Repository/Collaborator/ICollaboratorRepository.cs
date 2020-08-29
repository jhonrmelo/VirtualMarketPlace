using Domain.Models;
using Repository.Database.Generic;
using System.Collections.Generic;
using X.PagedList;
using CollaboratorModel = Domain.Models.CollaboratorModel;

namespace Repository.Collaborator
{
    public interface ICollaboratorRepository : IGenericRepository<CollaboratorModel>
    {
        CollaboratorModel Login(string Email, string Password);
        CollaboratorModel GetCollaborator(int id);
        List<CollaboratorModel> GetCollaborators();
        IPagedList<CollaboratorModel> GetPagedCollaborators(int page);
        IEnumerable<CollaboratorTypeModel> GetCollaboratorTypes();
        void UpdatePassword(CollaboratorModel collaborator);
        CollaboratorModel GetByEmail(string email);
    }
}
