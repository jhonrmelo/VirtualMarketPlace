using Domain.Models;
using Helpers;
using Repository.Database.Generic;
using System.Collections.Generic;
using VirtualMarketPlace.Repository.Database;
using X.PagedList;
using Microsoft.EntityFrameworkCore;
namespace Repository.Category
{
    public class CategoryRepository : GenericRepository<CategoryModel>, ICategoryRepository
    {
        private VirtualMarketPlaceContext _database;
        public CategoryRepository(VirtualMarketPlaceContext database) : base(database)
        {
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
            return _database.Categories.Include(x => x.FatherCategory).ToPagedList(index, Constants.RegPerPage);
        }
    }
}
