using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _context;

        public CategoryController(IUnitOfWork context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var GetProductOfCategories = _context.Products.FindAll(n => n.CatagoryId == id);

            return View(GetProductOfCategories);
        }

        [HttpPost]
        public IActionResult Index(string ProductName, int id)
        {

            var GetProductByNameInCategory = _context.Products
                .FindAll(x => x.Name.Contains(ProductName) && (x.CatagoryId == id));

            return View(GetProductByNameInCategory);
        }
    }
}
