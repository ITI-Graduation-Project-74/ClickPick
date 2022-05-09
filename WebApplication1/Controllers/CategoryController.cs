using ClickPick.CustomModels;
using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


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
            var products = _context.Products.FindAll(n => n.CatagoryId == id).ToList();
            ViewBag.Brands = new SelectList(_context.Brands.GetAll(), "Id", "BrandName");
            return View(new ProductViewModel()
            {
                Products = products,
                Filter = new FilterViewModel()
                {
                    CategoryId = id
                }
            });
        }

        //[HttpPost]
        //public IActionResult Index(string ProductName, int id)
        //{

        //    var GetProductByNameInCategory = _context.Products
        //        .FindAll(x => x.Name.Contains(ProductName) && (x.CatagoryId == id));

        //    return View(GetProductByNameInCategory);
        //}

        [HttpPost]
        public IActionResult Index(FilterViewModel filter)
        {
            var products = _context.Products.GetAll().Where(b => b.CatagoryId == filter.CategoryId);
            products = products.Where(e => e.BrandId == filter.BrandId || filter.BrandId == default);
            if (!string.IsNullOrEmpty(filter.SearchSrting))
            {
                products = products.Where(b => 
                b.Catagory.CategoryName.ToLower().Contains(filter.SearchSrting.ToLower()) ||
                b.Name.ToLower().Contains(filter.SearchSrting.ToLower()));
            }
            if (!string.IsNullOrEmpty(filter.MinPrice))
            {
                var min = int.Parse(filter.MinPrice);
                products = products.Where(b => b.Price >= min);
            }
            if (!string.IsNullOrEmpty(filter.MaxPrice))
            {
                var max = int.Parse(filter.MaxPrice);
                products = products.Where(b => b.Price <= max);
            }
            ViewBag.Brands = new SelectList(_context.Brands.GetAll(), "Id", "BrandName");
            return View(new ProductViewModel()
            {
                Products = products.ToList(),
                Filter = filter
            });
        }
    }
}
