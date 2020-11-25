using Domain.Models;

using Repository.Database.Generic;

using System.Collections.Generic;

using X.PagedList;

namespace Repository.Image
{
    public interface IImageRepository : IGenericRepository<ImageModel>
    {
        ImageModel GetImage(int id);

        IEnumerable<ImageModel> GetAll(int id);

        IPagedList<ImageModel> GetPagedImages(int page);

        IEnumerable<ImageModel> GetAllByProduct(int productId);



    }
}
