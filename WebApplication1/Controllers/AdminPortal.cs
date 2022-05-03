using ClickPick.Utility;
using Ecommerce.Models;
using Ecommerce.Models.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    
    [Authorize(Roles=ApplicationRoles.Role_Admin)]
    public class AdminPortal : Controller
    {
       public IActionResult Index()
        {
            return View();
        }



    }
}

