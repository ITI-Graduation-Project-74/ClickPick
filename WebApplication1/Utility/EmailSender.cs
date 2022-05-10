using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace ClickPick.Utility
{
    public class EmailSender : IEmailSender
    {
        public  Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var fromEmail = "esraa.abdelmonem.hassan@gmail.com";
            var fromPassword = "esraa12345";


            //var message = new MailMessage();
            //message.From = new MailAddress(fromEmail);
            //message.Subject = subject;

            //message.To.Add(email);

            //message.Body = $"<html> <body>{htmlMessage} </body></html>";
            //message.IsBodyHtml = true;

            //var smtpClient = new SmtpClient(host: "smtp.gmail.com")
            //{
            //    Port = 587,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential(fromEmail, fromPassword),
            //    EnableSsl = true,

            //};

            //smtpClient.Send(message);
            return Task.CompletedTask;
        }

    }
}
