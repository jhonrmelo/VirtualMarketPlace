using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Database.Generic;
using System.Collections.Generic;
using VirtualMarketPlace.Repository.Database;
using X.PagedList;

namespace Repository.Category
{
    public class CategoryRepository : GenericRepository<CategoryModel>, ICategoryRepository
    {
        private IConfiguration _conf;
        private VirtualMarketPlaceContext _database;
        public CategoryRepository(VirtualMarketPlaceContext database, IConfiguration configuration) : base(database)
        {
            _conf = configuration;
            _database = database;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return _database.Categories;
        }

        public CategoryModel GetCategory(int id)
        {
            return _database.Categories.Find(id);
        }

        public IPagedList<CategoryModel> GetPagedCategories(int index)
        {
            return _database.Categories.Include(x => x.FatherCategory).ToPagedList(index, _conf.GetValue<int>("RegPerPage"));
        }
    }
}
