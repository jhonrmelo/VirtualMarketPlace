using Microsoft.AspNetCore.Http;

using System.IO;

namespace Service.FileService
{
    public class FileService : IFileService
    {
        public string StoreProductImage(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/temp", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine("/uploads/temp", fileName);
        }

        public bool DeleteProductImage(string path)
        {
            string pathToDelete = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", path.TrimStart('/'));

            if (File.Exists(pathToDelete))
            {
                File.Delete(pathToDelete);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
