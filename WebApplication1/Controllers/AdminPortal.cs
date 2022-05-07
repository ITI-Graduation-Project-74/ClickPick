using ClickPick.Utility;
using Ecommerce.Data;
using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{

    [Authorize(Roles = ApplicationRoles.Role_Admin)]
    public class AdminPortal : Controller
    {
        private readonly AppDbContext _context;

        public AdminPortal(AppDbContext context)
        {
            _context = context;
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
        public IActionResult Approve(int id)
        {
           
                if(id != null)
                {

                    var Request = _context.Products.Where(x => x.Id == id).FirstOrDefault();
                    Request.IsApproved = true;
                    _context.Update(Request);
                    _context.SaveChanges();
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
            return RedirectToAction("PendingRequest");

        }


    }
}

