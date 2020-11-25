using Domain.Models;

using Microsoft.Extensions.Configuration;

using Repository.Database.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VirtualMarketPlace.Repository.Database;

using X.PagedList;

namespace Repository.Image
{
    public class ImageRepository : GenericRepository<ImageModel>, IImageRepository
    {
        private VirtualMarketPlaceContext _database;
        private IConfiguration _configuration;

        public ImageRepository(VirtualMarketPlaceContext database, IConfiguration configuration) : base(database)
        {
            _database = database;
            _configuration = configuration;
        }

        public ImageModel GetImage(int id)
        {
            return _database.Images.Find(id);
        }
        public IEnumerable<ImageModel> GetAll(int id)
        {
            return _database.Images;
        }

        public IPagedList<ImageModel> GetPagedImages(int page)
        {
            return _database.Images.ToPagedList(page, _configuration.GetValue<int>("RegPerPage"));
        }

        public IEnumerable<ImageModel> GetAllByProduct(int productId)
        {
            return _database.Images.Where(image => image.ProductId == productId);
        }
    }
}
