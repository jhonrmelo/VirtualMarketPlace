
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Category;
using Service.PipelineFilters;
using Service.Product;

using System.Linq;

namespace VirtualMarketPlace.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    [CollaboratorAuthorization(EnumCollaboratorType.Manager)]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int? page, string search)
        {
            var products = _productService.GetPagedProducts(page, search);
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            TempData["MSG_S"] = "Product removed!";
            return Json(new { status = true });
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _categoryService.GetCategories();
            ViewBag.Categories = categories.Select(category => new SelectListItem(category.Name, category.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _productService.GetById(id);
            return View(product);
        }
    }
}
