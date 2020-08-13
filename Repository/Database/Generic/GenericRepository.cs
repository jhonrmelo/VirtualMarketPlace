using VirtualMarketPlace.Repository.Database;

namespace Repository.Database.Generic
{
    public class GenericRepository<T> where T : class
    {
        private VirtualMarketPlaceContext _database;

        public GenericRepository(VirtualMarketPlaceContext database)
        {
            _database = database;
        }

        public void Create(T TModel)
        {
            _database.Add(TModel);
            _database.SaveChanges();
        }

        public void Delete(T TModel)
        {
            _database.Remove(TModel);
            _database.SaveChanges();
        }
        public void Update(T TModel)
        {
            _database.Update(TModel);
            _database.SaveChanges();
        }
    }
}
