using Domain.Models;

using Repository.Image;

using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Image
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public void Create(ImageModel image)
        {
            _imageRepository.Create(image);
        }
        public ImageModel GetById(int id)
        {
            return _imageRepository.GetImage(id);
        }
        public void Delete(int id)
        {
            var product = GetById(id);
            _imageRepository.Delete(product);
        }

        public void DeleteProductImages(int productId)
        {
            var imagesFromProduct = _imageRepository.GetAllByProduct(productId);
            _imageRepository.DeleteRange(imagesFromProduct);
        }

    }
}
