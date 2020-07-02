using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult ViewProduct()
        {
            var produto = _getProduto();

            return View(produto);
            // return  new ContentResult() { Content = "<h3> Produto > Visualizar </h3>", ContentType = "text/html" };
        }

        private Product _getProduto()
        {
            return new Product()
            {
                Id = 1,
                Name = "X-box",
                Description = "Video-Game",
                Value = 2000.00M
            };
        }
    }
}