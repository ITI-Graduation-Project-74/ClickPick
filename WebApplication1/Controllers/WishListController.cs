using ClickPick.Models.ViewModels;
using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClickPick.Controllers
{
    public class WishListController : Controller
    {
        private readonly IUnitOfWork _context;
        public WishListVM WishListVM { get; set; }

        //[AllowAnonymous]
        public WishListController(IUnitOfWork context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //var ProductsInSpecificCart = _context.Products.GetAll();

            WishListVM = new WishListVM()
            {
                WishList = _context.WishLists
                .FindAll(c => c.ApplicationUserId == claim.Value)
            };

            return View(WishListVM);
        }

        //wishList
     
        public IActionResult wishList(int productId)
        {
            WishList Obj = new()
            {

                ProductId = productId,
                Product = _context.Products.GetById(productId),
            };
            TempData["DetailsProductId"] = productId;
            return View(Obj);

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        [Authorize]


        public IActionResult wishList(WishList wishList)
        {
            // Get The Claim Of Logined User (ApplicationUserId)

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            wishList.ApplicationUserId = claim.Value;

            // checking If the User Exist on Database Or Not 

            WishList StoredWishInDb = _context.WishLists
                .Find(n => n.ApplicationUserId == claim.Value
                && n.ProductId == wishList.ProductId);

            if (StoredWishInDb == null)
            {
                _context.WishLists.Add(wishList);
                _context.Complete();

               

            }
            // Save To Database
            _context.Complete();
            TempData["wishList"] = "Added To Your WishList";
            return RedirectToAction("Details" , "Product" , new {productId=TempData["DetailsProductId"] });
        }
        public IActionResult delete(int productId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity
                .FindFirst(ClaimTypes.NameIdentifier);

            var wishListItem = _context.WishLists
                .Find(c => c.ApplicationUserId == claim.Value && c.ProductId == productId);

            _context.WishLists.Delete(wishListItem);
            _context.Complete();
            return RedirectToAction("Index");
        }
           



    }
}
