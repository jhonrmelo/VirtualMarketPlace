using Domain.Enums;
using Domain.Models;
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
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _categoryService.GetCategories();
            ViewBag.Categories = categories.Select(category => new SelectListItem(category.Name, category.Id.ToString()));
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                TempData["MSG_S"] = "Product created with success!";
                _productService.Create(product);
                return RedirectToAction(nameof(Index));
            }
            var categories = _categoryService.GetCategories();
            ViewBag.Categories = categories.Select(category => new SelectListItem(category.Name, category.Id.ToString()));
            return View();
        }

        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            TempData["MSG_S"] = "Product removed!";
            return Json(new { status = true });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _productService.GetById(id);
            var categories = _categoryService.GetCategories();
            ViewBag.Categories = categories.Select(category => new SelectListItem(category.Name, category.Id.ToString()));
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData["MSG_S"] = $"Product {product.Name} updated with success!";
                return RedirectToAction(nameof(Index));

            }

            var categories = _categoryService.GetCategories();
            ViewBag.Categories = categories.Select(category => new SelectListItem(category.Name, category.Id.ToString()));
            return View();
        }
    }
}
