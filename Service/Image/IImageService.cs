using Domain.Models;

namespace Service.Image
{
    public interface IImageService
    {
        void Create(ImageModel image);

        ImageModel GetById(int id);

        void Delete(int id);

        void DeleteProductImages(int productId);

    }
}
