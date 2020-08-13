using Domain.Models;

using System.Collections.Generic;
using X.PagedList;

namespace Service.Category
{
    public interface ICategoryService
    {
        void Create(CategoryModel category);
        void Update(CategoryModel category);
        void Delete(int id);
        CategoryModel GetCategory(int id);
        IEnumerable<CategoryModel> GetCategories();
        IPagedList<CategoryModel> GetPagedCategories(int? index);
    }
}
