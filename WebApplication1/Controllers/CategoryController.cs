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
    }
}
