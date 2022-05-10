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
            //var fromEmail = "manal.afifi525@gmail.com";
            //var fromPassword = "1234mM/1234mM/";

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
