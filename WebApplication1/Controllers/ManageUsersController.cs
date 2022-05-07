using Ecommerce.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ManageUsersController : Controller
    {
        private AppDbContext _context;
        public ManageUsersController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult UsersWithRoles()
        {
            var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleNames = (
      from userRole in _context.UserRoles
      join role in _context.Roles on userRole.RoleId equals role.Id
      where userRole.UserId == user.Id
      select role.Name).ToArray()
                                  }).ToList().Select(p => new Users_in_Role_ViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join("", p.RoleNames)
                                  });
            return View(usersWithRoles);
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
