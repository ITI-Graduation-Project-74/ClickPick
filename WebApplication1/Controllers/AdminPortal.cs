using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class AdminPortal : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


    }
}

