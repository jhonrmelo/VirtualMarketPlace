using Microsoft.AspNetCore.Http;

namespace Service.FileService
{
    public interface IFileService
    {
        string StoreProductImage(IFormFile file);
        bool DeleteProductImage(string path);
    }
}
