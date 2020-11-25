using Domain.Models;

using LinqKit;

using Repository.Database.Generic;

using System.Collections.Generic;

using X.PagedList;

namespace Repository.Product
{
    public interface IProductRepository : IGenericRepository<ProductModel>
    {
        ProductModel GetProduct(int id);
        IEnumerable<ProductModel> GetProducts();
        IPagedList<ProductModel> GetPagedProducts(int index, ExpressionStarter<ProductModel> whereExpression);

    }
}
