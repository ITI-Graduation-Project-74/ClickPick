using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ClickPick.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork _context;
        public PaymentController(IUnitOfWork context)
        {
            _context = context;
        }

        public IActionResult Index(String Method)
        {
            Coupon coupon = new Coupon();
            //Coupon
            if ((HttpContext.Session.GetString("coupon")) != null)
            {
                 coupon = JsonConvert.DeserializeObject<Coupon>(HttpContext.Session.GetString("coupon"));

            }

            //Payment
            Payment payment = new Payment() { Method = Method };

            //OrderDetails
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ShoppingCartVM cart = new ShoppingCartVM()
            {
                ListCart = _context.ShoppingCartServices
               .FindAll(c => c.ApplicationUserId == claim.Value)
            };
            List<Product> Products = new List<Product>();
            foreach (var item in cart.ListCart)
            {
                Products.Add(item.Product);
            }

            //OrderHeader
            var orderHeaderSession = JsonConvert.DeserializeObject<OrderHeader>(HttpContext.Session.GetString("orderHeader"));
            OrderHeader orderHeader = orderHeaderSession;
            _context.Payments.Add(payment);
            _context.Complete();

            _context.OrderHeaders.Add(orderHeader);
            _context.Complete();


            
            OrderDetails orderDetails=new OrderDetails()
            {
                OrderHeaderId= orderHeader.Id,
                Products = Products,
                OrderDateTime = DateTime.Now,
                PaymentId = payment.Id,
                status="Pending"
                
            };
            if (coupon.Id !=0)
            {
                orderDetails.CouponId = coupon.Id;
            }
            else
            {
                orderDetails.CouponId = null;
            }
            _context.OrderDetails.Add(orderDetails);
           
            _context.Complete();
            orderHeader.OrderDetails.Add(orderDetails);
            _context.Complete();

         

            HttpContext.Session.Remove("coupon");
            TempData.Remove("USD");
            return View();
        }
    }
}
