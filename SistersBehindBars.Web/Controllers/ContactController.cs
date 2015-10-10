using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

using SistersBehindBars.Web.Services;
using SistersBehindBars.Web.ViewModels;

namespace SistersBehindBars.Web.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.BaseUrl = Url.Action("Index", "Home");
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index", model);
            }
            try
            {
                var body = model.Message.Replace(Environment.NewLine, "<br />\r\n");

                var message = new MailMessage()
                {
                    Subject = "New Inquiry!",
                    Body = string.Format("<h3>Hello Sisters! Someone Has Messaged You!</h3><p>{0}</p><p><b>Contact Info:</b><br/>{1} {2}<br/>{3}<br/>{4}</p>", body, model.FirstName, model.LastName, model.Phone, model.Email),
                    IsBodyHtml = true,
                };

                message.To.Add(new MailAddress("sistersbehindbars@gmail.com"));

                SslMail.SendMail(message);
            }
            catch(SmtpException){
                ModelState.AddModelError("Error", "Oops! We are having issues sending the emails. Please try again later.");
                return View();
            }
            
            ViewBag.BaseUrl = Url.Action("Index", "Home");
            
            return RedirectToAction("Index");
        }
    }
}