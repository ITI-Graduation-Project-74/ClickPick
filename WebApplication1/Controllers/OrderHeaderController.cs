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
        public IActionResult Index(string Phone, string Address,int Shipping, string? Note, String? BillingAddress)
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
                Shipping= Shipping,
                BillingAddress = BillingAddress,
                ApplicationUserId=claim.Value
            };

           
            

            HttpContext.Session.SetString("orderHeader", JsonConvert.SerializeObject(orderHeader));
            return View("Payment");
        }
        

        // Order History 
        public  IActionResult OrdersHistory()
        {
            //user 
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //getting order
            List<OrderHeader> UserorderHeaders = _context.OrderHeaders.FindAll(a => a.ApplicationUserId == claim.Value).ToList();
            List<OrderDetails> orders = new List<OrderDetails>();
            foreach (var orderHeaderItem in UserorderHeaders)
            {
                List<OrderDetails> ordersI =  _context.OrderDetails.FindAll(a => a.OrderHeaderId == orderHeaderItem.Id).ToList();
                orders.AddRange(ordersI);
            }
            
            ViewBag.OrderDetails = orders;
            return View();
        }

        public  IActionResult OrderHistoryDetails( int Id)
        {
            //List<OrderDetails> orderHistoryDetail = await _context.OrderDetails.GetAllEagerLodingAsync(c => c.Id == Id, new[] { "Products" });
            // OrderDetails orderHistoryDetailWithoutProducts = orderHistoryDetail[0];
            // OrderHeader orderHeaderHistory = _context.OrderHeaders.Find(y => y.Id == orderHistoryDetailWithoutProducts.OrderHeaderId);
            // ViewBag.Orders=orderHistoryDetail;
            OrderDetails order = _context.OrderDetails.Find(c => c.Id == Id);
            List <Product> products= order.Products;
            OrderHeader orderHeaderHistory = _context.OrderHeaders.Find(y => y.Id == order.OrderHeaderId);
            ViewBag.order = order;
            ViewBag.Products = products;
            ViewBag.Header=orderHeaderHistory;
            return View();
        }

        public IActionResult CancelOrder(int orderId) {
           OrderDetails order= _context.OrderDetails.Find(a => a.Id == orderId);
            order.status = "Canceled";
            _context.Complete();

            return RedirectToAction("OrdersHistory");
        }





    }
}
