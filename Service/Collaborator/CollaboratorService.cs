using Domain.Models;
using Helpers;
using Microsoft.Extensions.Configuration;
using Repository.Collaborator;
using Service.Email;
using System.Collections.Generic;
using X.PagedList;
using CollaboratorModel = Domain.Models.CollaboratorModel;

namespace Service.Collaborator
{
    public class CollaboratorService : ICollaboratorService
    {
        private ICollaboratorRepository _collaboratorRepository;
        private IConfiguration _configuration;
        private IEmailService _emailService;

        public CollaboratorService(ICollaboratorRepository collaboratorRepository, IConfiguration configuration, IEmailService emailService)
        {
            _collaboratorRepository = collaboratorRepository;
            _configuration = configuration;
            _emailService = emailService;
        }
        public void Create(CollaboratorModel collaborator)
        {
            collaborator.Password = PasswordHelper.GeneratePassword(_configuration.GetValue<int>("PasswordSize"));
            //  _emailService.SendPassword(collaborator);
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
        public void CreatePassword(int collaboratorId)
        {
            CollaboratorModel collaborator = GetCollaborator(collaboratorId);
            string password = PasswordHelper.GeneratePassword(_configuration.GetValue<int>("PasswordSize"));
            collaborator.Password = password;
            UpdatePassword(collaborator);
            _emailService.SendPassword(collaborator);
        }

        public void UpdatePassword(CollaboratorModel collaborator)
        {
            _collaboratorRepository.UpdatePassword(collaborator);
        }

        public CollaboratorModel GetByEmail(string email)
        {
            return _collaboratorRepository.GetByEmail(email);
        }

        public bool IsCollaboratorEmailUnique(CollaboratorModel collaboratorToInsert)
        {
            var collaborator = GetByEmail(collaboratorToInsert.Email);
            if ((collaborator != null && collaboratorToInsert.Id == 0) || (collaborator != null && collaborator.Id != collaboratorToInsert.Id))
                return false;

            return true;
        }
    }
}
