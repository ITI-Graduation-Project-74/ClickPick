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
        public IActionResult Index(string ProductName,int id)
        {
            var GetProductOfCategories = _context.Products.FindAll(n => n.CatagoryId == id);
            ViewBag.CategoryId = id;
            
            if(ProductName is not null)
            {

                GetProductOfCategories= GetProductOfCategories.Where(x => x.Name.Contains(ProductName) && (x.CatagoryId == id));
            }

            return View(GetProductOfCategories);
        }
        
        // search in category 

       
        
        //public IActionResult Index(string ProductName, int id)
        //{
            
        //    var GetProductByNameInCategory = _context.Products
        //        .FindAll(x => x.Name.Contains(ProductName) && (x.CatagoryId == id));
        //    ViewBag.CategoryId = id;
        //    return View(GetProductByNameInCategory);


        //}
    }
}
