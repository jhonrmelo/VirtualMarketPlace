using Domain.Models;
using Repository.Database.Generic;
using System.Collections.Generic;
using X.PagedList;

namespace Repository.Category
{
    public interface ICategoryRepository : IGenericRepository<CategoryModel>
    {
        CategoryModel GetCategory(int id);
        IEnumerable<CategoryModel> GetCategories();

        IPagedList<CategoryModel> GetPagedCategories(int index);

    }
}
