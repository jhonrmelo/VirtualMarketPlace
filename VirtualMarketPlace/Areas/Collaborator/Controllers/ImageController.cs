using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.FileService;
using Service.PipelineFilters;

namespace VirtualMarketPlace.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    [CollaboratorAuthorization(EnumCollaboratorType.Manager)]
    public class ImageController : Controller
    {
        private IFileService _fileService;

        public ImageController(IFileService fileService)
        {
            _fileService = fileService;
        }
        public IActionResult Store(IFormFile file)
        {
            var path = _fileService.StoreProductImage(file);

            if (path.Length > 0)
            {
                return Ok(new { path });
            }
            else
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        public IActionResult Delete(string path)
        {
            if (_fileService.DeleteProductImage(path))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
