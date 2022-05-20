using Microsoft.AspNetCore.Mvc;
using Ecommerce.Models.Repositories.UnitOfWork;
using Ecommerce.Models;
using Ecommerce.Models.ViewModels;
using System.Security.Claims;
using Newtonsoft.Json;

namespace ClickPick.Controllers
{
    public class CouponController : Controller
    {
        private readonly IUnitOfWork _context;

                public CouponController(IUnitOfWork context)
        {
            _context = context;
        }
        public IActionResult Index(String Name)
        {
            //listcart
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            ViewBag.ShoppingCartVM = new ShoppingCartVM()
            {
                ListCart = _context.ShoppingCartServices
                .FindAll(c => c.ApplicationUserId == claim.Value)
            };

            HttpContext.Session.Remove("coupon");
            Coupon c = _context.Coupons.Find(a => a.Name == Name);
            if (c == null)
            {
                return Json(new { msg = "Not Applicaple" });

            }
            else
            {
                DateTime thisDay = DateTime.Today;
                int expire = DateTime.Compare(thisDay, c.ValidTo);
                int valid = DateTime.Compare(thisDay, c.ValidFrom);
                if (valid < 0)
                {
                    return Json(new { msg = "Not Applicaple yet" });
                }
                else if (expire > 0)
                {
                    return Json(new { msg = "sorry this coupon expired" });
                }
                else
                {
                    string jsonC = JsonConvert.SerializeObject(c);
                    HttpContext.Session.SetString("coupon", jsonC);
                    return Json(new { msg = c.Percentage });


                }
            }

        }
        public string Remove()
        {
            HttpContext.Session.Remove("coupon");
            return "coupon removed ";
        }

        public string checkPhone(String phone)
        {
            ApplicationUser user = _context.ApplicationUsers.Find(u => u.PhoneNumber == phone);
            if (user == null)
            {
                return " ";
            }
            else return "Sorry, This Phone number already exists";
           

        }
    }
}
