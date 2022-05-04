using ClickPick.Utility;
using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClickPick.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _context;

        public ShoppingCartViewComponent(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                //if (HttpContext.Session.GetInt32(StaticDetails.SessionCart) != null)
                //{
                //    return View(HttpContext.Session.GetInt32(StaticDetails.SessionCart));
                //}
                //else
                //{

                //    HttpContext.Session.SetInt32(StaticDetails.SessionCart,
                //        _context.ShoppingCarts.FindAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
                //    return View(HttpContext.Session.GetInt32(StaticDetails.SessionCart));

                //}
                return View(_context.ShoppingCarts.FindAll(c => c.ApplicationUserId == claim.Value).Sum(c => c.Count));
            }
            else
            {
                //HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}