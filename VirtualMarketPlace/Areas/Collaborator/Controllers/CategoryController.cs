using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Category;
using Service.PipelineFilters;
using System.Linq;
using X.PagedList;

namespace VirtualMarketPlace.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    [CollaboratorAuthorization]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index(int? index)
        {
            var lstPagedCategories = _categoryService.GetPagedCategories(index);
            return View(lstPagedCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categorias = _categoryService.GetCategories().Select(lcategory => new SelectListItem(lcategory.Name, lcategory.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(category);
                TempData["MSG_S"] = "Category created with success!";

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _categoryService.GetCategories().Select(lcategory => new SelectListItem(lcategory.Name, lcategory.Id.ToString()));

            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CategoryModel categorySelected = _categoryService.GetCategory(id);
            ViewBag.Categorias = _categoryService.GetCategories().Where(lcategory => lcategory.Id != id).Select(lcategory => new SelectListItem(lcategory.Name, lcategory.Id.ToString()));
            return View(categorySelected);
        }
        [HttpPost]
        public IActionResult Update([FromForm] CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(category);
                TempData["MSG_S"] = "Category saved with success!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categorias = _categoryService.GetCategories().Where(lcategory => lcategory.Id != category.Id).Select(lcategory => new SelectListItem(lcategory.Name, lcategory.Id.ToString()));
            return View(category);
        }
        [HttpGet]
        [ValidateHTTPReferer]
        public IActionResult Delete(int id)
        {
            TempData["MSG_S"] = "Category removed!";
            _categoryService.Delete(id);

            return Json(new { status = true });
        }
    }
}