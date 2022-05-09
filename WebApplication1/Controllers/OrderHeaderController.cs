using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Ecommerce.Controllers
{
    public class OrderHeaderController : Controller
    {
        private readonly IUnitOfWork _context;
        public OrderHeaderController(IUnitOfWork context)
        {
            _context = context;
        }
        public IActionResult Index(int Phone, string Address, string? Note, String? BillingAddress)
        {
            //Order Details
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //claimsIdentity.FindFirst(ClaimTypes.)
            //var ProductsInSpecificCart = _context.Products.GetAll();

            ShoppingCartVM cart = new ShoppingCartVM()
            {
                ListCart = _context.ShoppingCartServices
                .FindAll(c => c.ApplicationUserId == claim.Value)
            };
            ViewBag.ShoppingCartVM = cart;

            ApplicationUser user = _context.ApplicationUsers.Find(u => u.Id == claim.Value);

            OrderHeader orderHeader = new OrderHeader()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = Phone,
                Address = Address,
                Note = Note,
                OrderDateTime = DateTime.Now,
                BillingAddress = BillingAddress,
                ApplicationUserId=claim.Value
            };

           
            

            HttpContext.Session.SetString("orderHeader", JsonConvert.SerializeObject(orderHeader));
            return View("Payment");
        }
        

        // Order History 
        public IActionResult OrdersHistory()
        {
            return View();
        }
    }
}
