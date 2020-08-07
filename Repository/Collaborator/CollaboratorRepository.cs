using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Repository.Database;
using Microsoft.EntityFrameworkCore;
using CollaboratorModel = Domain.Models.CollaboratorModel;

namespace Repository.Collaborator
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private VirtualMarketPlaceContext _database;
        public CollaboratorRepository(VirtualMarketPlaceContext database)
        {
            _database = database;
        }
        public void Create(CollaboratorModel collaborator)
        {
            _database.Add(collaborator);
            _database.SaveChanges();
        }

        public void Delete(CollaboratorModel collaborator)
        {
            _database.Remove(collaborator);
            _database.SaveChanges();
        }

        public CollaboratorModel GetCollaborator(int id)
        {
            return _database.Collaborators.Include(x => x.CollaboratorType).SingleOrDefault(x => x.Id == id);
        }

        public List<CollaboratorModel> GetCollaborators()
        {
            return _database.Collaborators.Include(x => x.CollaboratorType).ToList();
        }

        public CollaboratorModel Login(string Email, string Password)
        {
            return _database.Collaborators.Include(x => x.CollaboratorType).Where(collaborator => collaborator.Email == Email
                                                                            && collaborator.Password == Password)
                                                                            .FirstOrDefault();
        }

        public void Update(CollaboratorModel collaborator)
        {
            _database.Update(collaborator);
            _database.SaveChanges();
        }
    }
}
