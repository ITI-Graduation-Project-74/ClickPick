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


            Coupon c = _context.Coupons.Find(a => a.Name == Name);
            if (c == null)
            {
                ViewBag.msg = "Not Applicaple";
                TempData.Remove("coupon");
                return View("CartSummary");
            }
            else
            {
                DateTime thisDay = DateTime.Today;
                int expire = DateTime.Compare(thisDay, c.ValidTo);
                int valid = DateTime.Compare(thisDay, c.ValidFrom);
                if (valid < 0)
                {
                    ViewBag.msg = "Not Applicaple yet";
                    TempData.Remove("coupon");
                    return View("CartSummary");
                }
                else if (expire > 0)
                {
                    ViewBag.msg = "sorry this coupon expired";
                    TempData.Remove("coupon");
                    return View("CartSummary");
                }
                else
                {
                    TempData["coupon"] = c.Percentage;
                    HttpContext.Session.SetString("coupon", JsonConvert.SerializeObject(c));
                    return View("CartSummary");

                }
            }

        }
        public IActionResult Remove()
        {
            TempData.Remove("coupon");
            ViewBag.msg = "coupon removed";
            return View("CartSummary");
        }
    }
}
