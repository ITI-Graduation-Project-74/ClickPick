using ClickPick.Utility;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{

    [Authorize(Roles = ApplicationRoles.Role_Admin)]

    public class AdminPortal : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailSender _email;
        public AdminPortal(AppDbContext context, IEmailSender email)
        {
            _context = context;
            this._email = email;
        }

        public IActionResult Index()
        {
            var totalpendingproudcts = _context.Products.Where(x => x.IsApproved == false).Count();
            ViewBag.TPP = totalpendingproudcts;
            return View();
        }

        [HttpGet]
        public IActionResult PendingRequest()
        {
            try
            {
               
                    var PendingProducts = _context.Products.Where(x => x.IsApproved == false).ToList();
                    return View(PendingProducts);
                 
            }
            
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task <IActionResult> Approve(int id)
        {
           
                if(id != null)
                {

                    var Product = _context.Products.Where(x => x.Id == id).FirstOrDefault();
                    Product.IsApproved = true;
                    _context.Update(Product);
                    _context.SaveChanges();
                var Email = _context.Users.FirstOrDefault(x => x.Id==Product.UserId).Email;
            await _email.SendEmailAsync(Email, "Approved Product", "The Product is sufficient to display it on our Website");

                return RedirectToAction("PendingRequest");
                }
            
           
            return RedirectToAction("PendingRequest");
            

        }

        [HttpPost]
        public async Task<IActionResult>  Reject(int id)
        {


            //var Request =await _context.Products.Where(x => x.Id == id).FirstOrDefault();
           
            //_context.Remove(Request);
            //_context.SaveChanges();
           // _context.Products.Remove(Request);
           // await _context.SaveChangesAsync();
           // return RedirectToAction("PendingRequest");

            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            var Email = _context.Users.FirstOrDefault(x => x.Id == product.UserId).Email;

            await _email.SendEmailAsync(Email, "Reject Product", "The Product is not sufficient to display it on our Website");
            return RedirectToAction("PendingRequest");

        }
        public IActionResult UsersWithOrders()
        {
            var viewresult = _context.UsersWithorders.ToList();

            return View(viewresult);
        }

    }
}


