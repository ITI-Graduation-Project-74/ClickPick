using ClickPick.Utility;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Models.PagedList;
using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _context;
        

        public ProductController(IUnitOfWork context )
        {
            _context = context;
           
        }
        public IActionResult Index(int Page=1)
        {
            var products = _context.Products.GetAll();
            var categories = _context.Categories.GetAll();

            // Pages List 
            const int PageSize = 12;

            int ResultCount = products.Count();

            var Pages = new Pages(ResultCount,Page, PageSize);

            int ResultPage = (Page - 1) * PageSize;

            // Return into View

            var data= products.Skip(ResultPage).Take(Pages.PageSize).ToList();

            // Working On View

            ViewBag.DataView = Pages;




            dynamic ProductCategory = new ExpandoObject();
            ProductCategory.Product = data;
            ProductCategory.Category = categories;

            return View(ProductCategory);
        }

        //public IActionResult ProductDetails(int id)
        //{

        //    var productDetails = _context.Products.GetById(id);
        //    if (productDetails == null)
        //        return View("Error");
        //    return View(productDetails);
        //}

        public IActionResult ProductDetails(int id)
        {

            var productDetails = _context.ProductImgs.FindAll(x => x.ProductId == id);
            if (productDetails == null)
                return View("Error");
            return View(productDetails);
        }

        //Cart
        public IActionResult Details(int productId)
        {
            ShoppingCart cartObj = new()
            {
                Count = 1,
                ProductId= productId,
                Product = _context.Products.GetById(productId),
            };
            return View(cartObj);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        [Authorize]
        //public IActionResult Details(ShoppingCart shoppingCart)
        //{
        //    // Get The Claim Of Logined User (ApplicationUserId)

        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //    shoppingCart.ApplicationUserId = claim.Value;

        //    // checking If the User Exist on Database Or Not 

        //    ShoppingCart StoredCartInDb = _context.ShoppingCarts
        //        .Find(n => n.ApplicationUserId == claim.Value 
        //        && n.ProductId == shoppingCart.ProductId);

        //    if(StoredCartInDb == null)
        //    {
        //        _context.ShoppingCarts.Add(shoppingCart);
        //    }
        //    else
        //    {
        //        _context.ShoppingCartServices
        //            .IncrementCount(StoredCartInDb, shoppingCart.Count);
        //    }
            
        //    // Save To Database
        //    _context.Complete();

        //    return RedirectToAction("Index"); 
        //}

        public IActionResult Details(ShoppingCart shoppingCart)
        {
            // Get The Claim Of Logined User (ApplicationUserId)

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;

            // checking If the User Exist on Database Or Not 

            ShoppingCart StoredCartInDb = _context.ShoppingCarts
                .Find(n => n.ApplicationUserId == claim.Value
                && n.ProductId == shoppingCart.ProductId);

            if (StoredCartInDb == null)
            {
                _context.ShoppingCarts.Add(shoppingCart);
                _context.Complete();
                HttpContext.Session
                    .SetInt32(StaticDetails.SessionCart,
                    _context.ShoppingCarts
                    .FindAll(u => u.ApplicationUserId == claim.Value).ToList().Count);  
            }
            else
            {
                _context.ShoppingCartServices
                    .IncrementCount(StoredCartInDb, shoppingCart.Count);
                _context.Complete();
            }

            // Save To Database
            _context.Complete();

            return RedirectToAction("Index");
        }

        public IActionResult SearchByInsideCategory(string ProductName, int id)
        {

            var GetProductByNameInCategory = _context.Products
                .FindAll(x => x.Name.Contains(ProductName)&& (x.CatagoryId==id));

            return View("SearchByName", GetProductByNameInCategory);
        } 
        public IActionResult SearchByName(string ProductName)
        {
            var GetProductByName = _context.Products.FindAll(x => x.Name.Contains(ProductName));

            return View(GetProductByName);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

    }
}
