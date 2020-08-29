using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Database.Generic;
using System.Collections.Generic;
using System.Linq;
using VirtualMarketPlace.Repository.Database;
using X.PagedList;

namespace Repository.Collaborator
{
    public class CollaboratorRepository : GenericRepository<CollaboratorModel>, ICollaboratorRepository
    {
        private VirtualMarketPlaceContext _database;
        private IConfiguration _conf;
        public CollaboratorRepository(VirtualMarketPlaceContext database, IConfiguration configuration) : base(database)
        {
            _database = database;
            _conf = configuration;
        }

        public CollaboratorModel GetCollaborator(int id)
        {
            return _database.Collaborators.Include(x => x.CollaboratorType).SingleOrDefault(x => x.Id == id);
        }

        public List<CollaboratorModel> GetCollaborators()
        {
            return _database.Collaborators.Include(x => x.CollaboratorType).ToList();
        }

        public IPagedList<CollaboratorModel> GetPagedCollaborators(int index)
        {
            return _database.Collaborators.Include(x => x.CollaboratorType).Where(collaborator => collaborator.CollaboratorTypeId != (int)EnumCollaboratorType.Manager).ToPagedList(index, _conf.GetValue<int>("RegPerPage"));
        }


        public CollaboratorModel Login(string Email, string Password)
        {
            return _database.Collaborators.Include(x => x.CollaboratorType).Where(collaborator => collaborator.Email == Email
                                                                            && collaborator.Password == Password)
                                                                            .FirstOrDefault();
        }

        public IEnumerable<CollaboratorTypeModel> GetCollaboratorTypes()
        {
            return _database.CollaboratorTypes;
        }

        public new void Update(CollaboratorModel collaborator)
        {
            _database.Update(collaborator);
            _database.Entry(collaborator).Property(x => x.Password).IsModified = false;
            _database.SaveChanges();
        }

        public void UpdatePassword(CollaboratorModel collaborator)
        {
            _database.Update(collaborator);
            _database.Entry(collaborator).Property(x => x.Name).IsModified = false;
            _database.Entry(collaborator).Property(x => x.Email).IsModified = false;
            _database.SaveChanges();
        }

        public CollaboratorModel GetByEmail(string email)
        {
            return _database.Collaborators.Where(collaborator => collaborator.Email == email).AsNoTracking().FirstOrDefault();
        }
    }
}
