using Domain.Models;
using Repository.Collaborator;
using System.Collections.Generic;
using X.PagedList;
using CollaboratorModel = Domain.Models.CollaboratorModel;

namespace Service.Collaborator
{
    public class CollaboratorService : ICollaboratorService
    {
        private ICollaboratorRepository _collaboratorRepository;

        public CollaboratorService(ICollaboratorRepository collaboratorRepository)
        {
            _collaboratorRepository = collaboratorRepository;
        }
        public void Create(CollaboratorModel collaborator)
        {
            _collaboratorRepository.Create(collaborator);
        }

        public void Delete(int id)
        {

            CollaboratorModel collaborator = GetCollaborator(id);
            _collaboratorRepository.Delete(collaborator);
        }

        public CollaboratorModel GetCollaborator(int id)
        {
            return _collaboratorRepository.GetCollaborator(id);
        }

        public List<CollaboratorModel> GetCollaborators()
        {
            return _collaboratorRepository.GetCollaborators();
        }

        public IPagedList<CollaboratorModel> GetPagedCollaborators(int? page)
        {
            int indexPage = page ?? 1;
            return _collaboratorRepository.GetPagedCollaborators(indexPage);

        }

        public CollaboratorModel Login(string Email, string Password)
        {
            return _collaboratorRepository.Login(Email, Password);
        }

        public void Update(CollaboratorModel collaborator)
        {
            _collaboratorRepository.Update(collaborator);
        }
        public IEnumerable<CollaboratorTypeModel> GetCollaboratorTypes()
        {
            return _collaboratorRepository.GetCollaboratorTypes();
        }
    }
}
