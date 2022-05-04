using Ecommerce.Data;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ecommerce.Models.Repositories.UnitOfWork;
using ClickPick.Utility;

namespace Ecommerce.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _context;
        public ShoppingCartVM ShoppingCartVM { get; set; }

        //[AllowAnonymous]
        public ShoppingCartController(IUnitOfWork context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //var ProductsInSpecificCart = _context.Products.GetAll();

            ShoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _context.ShoppingCartServices
                .FindAll(c => c.ApplicationUserId == claim.Value)
            };
            
            return View (ShoppingCartVM);
        }

        public IActionResult CartSummary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //var ProductsInSpecificCart = _context.Products.GetAll();

            ViewBag.ShoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _context.ShoppingCartServices
                .FindAll(c => c.ApplicationUserId == claim.Value)
            };
            return View(ShoppingCartVM);
        }

        public IActionResult IncreaseProduct(int productId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var cart =_context.ShoppingCarts
                .Find(c => c.ApplicationUserId == claim.Value && c.ProductId==productId);

            _context.ShoppingCartServices.IncrementCount(cart, 1);

            _context.Complete();

            var count = _context.ShoppingCarts.FindAll(c => c.ApplicationUserId == cart.ApplicationUserId).Sum(c => c.Count);
            HttpContext.Session.SetInt32(StaticDetails.SessionCart, count);

            return RedirectToAction("Index");
        }

        public IActionResult DecreaseProduct(int productId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity
                .FindFirst(ClaimTypes.NameIdentifier);

            var cart = _context.ShoppingCarts
                .Find(c => c.ApplicationUserId == claim.Value && c.ProductId == productId);
            if(cart.Count <= 1)
            {
                _context.ShoppingCartServices.Delete(cart);
                
                var count = _context.ShoppingCarts.FindAll(c => c.ApplicationUserId == cart.ApplicationUserId).ToList().Count-1;
                HttpContext.Session.SetInt32(StaticDetails.SessionCart, count);

            } else
            {
                _context.ShoppingCartServices.DecrementCount(cart, 1);
            }

            _context.Complete();

            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int productId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity
                .FindFirst(ClaimTypes.NameIdentifier);

            var cart = _context.ShoppingCarts
                .Find(c => c.ApplicationUserId == claim.Value && c.ProductId == productId);

           
            _context.ShoppingCartServices.Delete(cart);
            _context.Complete();
            var count = _context.ShoppingCarts.FindAll(c => c.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
            HttpContext.Session.SetInt32(StaticDetails.SessionCart, count);

            

            return RedirectToAction("Index");
        }

        //public double GetShoppingCartTotal()
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity
        //        .FindFirst(ClaimTypes.NameIdentifier);

        //    var CartTotal = _context.ShoppingCarts
        //         .Find(c => c.ApplicationUserId == claim.Value && c.ProductId == productId)

        //}


    }
}
