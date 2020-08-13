using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Repository.Database;
using Microsoft.EntityFrameworkCore;
using CollaboratorModel = Domain.Models.CollaboratorModel;
using Repository.Database;
using Repository.Database.Generic;

namespace Repository.Collaborator
{
    public class CollaboratorRepository : GenericRepository<CollaboratorModel>, ICollaboratorRepository
    {
        private VirtualMarketPlaceContext _database;
        public CollaboratorRepository(VirtualMarketPlaceContext database) : base(database)
        {
            _database = database;
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

    }
}
