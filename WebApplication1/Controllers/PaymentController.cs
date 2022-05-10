using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Ecommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe.Checkout;
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
            long stripeTotalAmount = 0;

            foreach (var item in cart.ListCart) 
            {
                stripeTotalAmount += (long)(item.Product.Price * 100);
                Products.Add(item.Product);
            }

            //OrderHeader
            var orderHeaderSession = JsonConvert.DeserializeObject<OrderHeader>(HttpContext.Session.GetString("orderHeader"));
            OrderHeader orderHeader = orderHeaderSession;
            _context.Payments.Add(payment);
            _context.Complete();
            _context.OrderHeaders.Add(orderHeader);
            _context.Complete();


            OrderDetails orderDetails = new OrderDetails()
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

            // Payment With Stripe 
        if (Method == "Stripe")
            {
                var domain = "https://localhost:7199/";
                var options = new SessionCreateOptions
                {
                    LineItems = new List<SessionLineItemOptions>(),
                    Mode = "payment",
                    SuccessUrl = domain + $"Payment/OrderConfirmedWithStripe?id={orderDetails.OrderHeaderId}",
                    CancelUrl = domain + $"Payment/OrderCanceled?id={orderDetails.OrderHeaderId}",
                };
               
                if (coupon.Id != 0)
                    
                {
                    stripeTotalAmount = stripeTotalAmount - ((stripeTotalAmount * coupon.Percentage) / 100);
                }
               
                foreach (var item in cart.ListCart)
                {

                    var sessionLineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = stripeTotalAmount, // If The Price is 20.00 we should multiple it to be 2000  
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Product.Name,
                                Description = item.Product.Description,

                            },
                        },
                        Quantity = item.Count,
                    };
                    options.LineItems.Add(sessionLineItem);
                }


                var service = new SessionService();
                Session session = service.Create(options);

                orderHeader.SessionId = session.Id;
                orderHeader.PaymentStripeId = session.PaymentIntentId;

                _context.Complete();
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }
            



            HttpContext.Session.Remove("coupon");
            TempData.Remove("USD");

            return View();
        }

      
        
        public IActionResult OrderConfirmedWithStripe()
        {

            return View();
        }

        public IActionResult OrderCanceled()
        {
            return View();

        }
    }
}
