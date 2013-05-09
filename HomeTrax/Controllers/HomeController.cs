using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using HomeTrax.Models;

namespace HomeTrax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (User.IsInRole("Agent"))
            //    return RedirectToAction("Index", "Agent");
            //else if (User.IsInRole("Buyer"))
            //    return RedirectToAction("Index", "Buyer");

            ViewBag.Message = "Welcome to Hometrax: Your one stop shop for home buying needs.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SendEmail(string name, string toEmail, string message)
        public ActionResult SendEmail(ContactInfoModel c)
        {
            if (ModelState.IsValid)
            {
                string email = "test@gmail.com";
                string password = "test";

                var loginInfo = new NetworkCredential(email, password);
                var mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);

                mail.From = new MailAddress("test@gmail.com");
                mail.To.Add(c.Email);
                mail.Subject = "Email From HomeTrax User: " + c.Name;
                mail.Body = c.Message;
                mail.IsBodyHtml = true;

                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = loginInfo;
                SmtpServer.Send(mail);
                return RedirectToAction("Contact", "Home");
            }

            return View("Contact");

        }
    }
}
