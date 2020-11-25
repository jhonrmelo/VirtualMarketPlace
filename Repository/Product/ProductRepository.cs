using Domain.Models;

using LinqKit;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Repository.Database.Generic;

using System.Collections.Generic;
using System.Linq;

using VirtualMarketPlace.Repository.Database;

using X.PagedList;

namespace Repository.Product
{
    public class ProductRepository : GenericRepository<ProductModel>, IProductRepository
    {
        private VirtualMarketPlaceContext _database;
        private IConfiguration _conf;

        public ProductRepository(VirtualMarketPlaceContext database, IConfiguration configuration) : base(database)
        {
            _database = database;
            _conf = configuration;
        }

        public ProductModel GetProduct(int id)
        {
            return _database.Products
                    .Include(product => product.Images)
                    .Include(product => product.Category)
                    .FirstOrDefault(product => product.Id == id);
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            return _database.Products.Include(product => product.Images)
                                     .Include(product => product.Category);
        }
        public IPagedList<ProductModel> GetPagedProducts(int index, ExpressionStarter<ProductModel> whereExpression)
        {
            if (whereExpression.IsStarted)
                return _database.Products.Include(product => product.Images)
                                         .Include(product => product.Category)
                                         .Where(whereExpression)
                                         .ToPagedList(index, _conf.GetValue<int>("RegPerPage"));

            return _database.Products.Include(product => product.Images)
                                     .Include(product => product.Category)
                                     .ToPagedList(index, _conf.GetValue<int>("RegPerPage"));
        }

    }
}
