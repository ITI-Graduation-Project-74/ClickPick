using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Ecommerce.Data;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.Controllers
{
    public class OrderHeaderController : Controller
    {
        private readonly IUnitOfWork _context;
        public OrderHeaderController(IUnitOfWork context)
        {
            _context = context;
        }
        public IActionResult Index(int Phone, string Address, string? Note, bool isSaved, String? BillingAddress)
        {

            //Save this information for next time

            //Order Details
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //var ProductsInSpecificCart = _context.Products.GetAll();

            ShoppingCartVM cart = new ShoppingCartVM()
            {
                ListCart = _context.ShoppingCartServices
                .FindAll(c => c.ApplicationUserId == claim.Value)
            };
            ViewBag.ShoppingCartVM = cart;


            OrderHeader orderHeader = new OrderHeader()
            {
                PhoneNumber = Phone,
                Address = Address,
                Note = Note,
                OrderDateTime = DateTime.Now,
                BillingAddress = BillingAddress,
            };
            //save the orderHeader
            //_context.OrderHeaders.Add(orderHeader);
            //_context.Complete();
            ViewBag.orderHeader = orderHeader;

            return View("Payment");
        }

        public IActionResult BillingAddress(string BillingAddress)
        {
            //Order Details
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //var ProductsInSpecificCart = _context.Products.GetAll();

            ShoppingCartVM cart = new ShoppingCartVM()
            {
                ListCart = _context.ShoppingCartServices
                .FindAll(c => c.ApplicationUserId == claim.Value)
            };
            ViewBag.ShoppingCartVM = cart;
            if (BillingAddress == "on")
            {
                ViewBag.BillingAddress = "true";
                return View("CartSummary");
            }
            else
            {
                ViewBag.BillingAddress = "false";
            }
            return View("CartSummary");
        }


    }
}
