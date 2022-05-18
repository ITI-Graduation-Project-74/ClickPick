using ClickPick.Models;
using Ecommerce.Models;
using Ecommerce.Models.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
   

        // private readonly IEmailSender _email;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // this._email = email;
       
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUs ContactU)
        {
            if (!ModelState.IsValid) return View();
            try
            {


                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("omar7mohamed4@gmail.com");
                mail.To.Add("esraaabdelmonem0@gmail.com");
                mail.Subject = ContactU.Subject;
                mail.IsBodyHtml = true;
                string Contact = "Name : " + ContactU.Name;
                Contact += "<br/> Message : " + ContactU.Message;
                mail.Body = Contact;

                SmtpClient SmtpClient = new SmtpClient("smtp.mailtrap.io");
                NetworkCredential NetworkCredential = new NetworkCredential("156ff941616c90", "d51a22689d2289");
                SmtpClient.UseDefaultCredentials = false;
                SmtpClient.Credentials = NetworkCredential;
                SmtpClient.Port = 587;
                SmtpClient.EnableSsl = false;
                SmtpClient.Send(mail);

                ViewBag.Message = "Mail Send";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message.ToString();
            }
            return View();
        }
    }
}