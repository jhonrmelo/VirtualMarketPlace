using Domain.Models;
using System.Collections.Generic;
using X.PagedList;
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
        IPagedList<CollaboratorModel> GetPagedCollaborators(int? page);
        IEnumerable<CollaboratorTypeModel> GetCollaboratorTypes();
        void CreatePassword(int collaboratorId);
        void UpdatePassword(CollaboratorModel collaborator);
        CollaboratorModel GetByEmail(string email);
        bool IsCollaboratorEmailUnique(CollaboratorModel collaboratorToInsert);
    }
}
