using Domain.Models;

using X.PagedList;

namespace Service.Product
{
    public interface IProductService
    {
        void Create(ProductModel product);

        ProductModel GetById(int id);

        void Update(ProductModel product);

        void Delete(int id);

        IPagedList<ProductModel> GetPagedProducts(int? page, string search);

    }
}
