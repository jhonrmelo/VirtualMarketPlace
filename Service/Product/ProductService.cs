using Domain.Models;

using LinqKit;

using Microsoft.Extensions.Configuration;

using System;
using Repository.Product;

using X.PagedList;

namespace Service.Product
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(ProductModel product)
        {
            _productRepository.Create(product);
        }
        public ProductModel GetById(int id)
        {
            return _productRepository.GetProduct(id);
        }
        public void Update(ProductModel product)
        {
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            _productRepository.Delete(product);
        }

        public IPagedList<ProductModel> GetPagedProducts(int? page, string search)
        {
            var predicate = PredicateBuilder.New<ProductModel>();

            if (!string.IsNullOrEmpty(search))
                predicate.And(x => x.Name.ToUpper().Contains(search));

            int indexPage = page ?? 1;
            return _productRepository.GetPagedProducts(indexPage, predicate);
        }

    }
}
