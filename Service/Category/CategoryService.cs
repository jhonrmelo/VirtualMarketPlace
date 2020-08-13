using Domain.Models;
using Repository.Category;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Service.Category
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(CategoryModel category)
        {
            _categoryRepository.Create(category);
        }

        public void Delete(int id)
        {

            CategoryModel category = GetCategory(id);
            _categoryRepository.Delete(category);
        }

        public CategoryModel GetCategory(int id)
        {
            return _categoryRepository.GetCategory(id);
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
        public void Update(CategoryModel category)
        {
            _categoryRepository.Update(category);
        }

        public IPagedList<CategoryModel> GetPagedCategories(int? index)
        {
            int indexPage = index ?? 1;
            return _categoryRepository.GetPagedCategories(indexPage);
        }
    }
}
