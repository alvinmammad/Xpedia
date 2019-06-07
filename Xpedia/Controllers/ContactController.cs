using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Xpedia.DAL;
namespace Xpedia.Controllers
{
    public class ContactController : BaseController
    {
        // GET: Contact
        
        public ActionResult Contact()
        {
            return View();
        }

        public JsonResult Message(string name , string surname , string phone , string email , string message)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(message))
            {
                Response.StatusCode = 406;
                return Json("Xanaları doldurun !", JsonRequestBehavior.AllowGet);
            }

            var body = "<ul><li>Name : {0}</li><li>Surname: {1}</li><li>Email : {2}</li><li>Phone : {3}</li></ul><p>{4}</p>";
            var MailMessage = new MailMessage();
            MailMessage.To.Add(new MailAddress("elvinem@code.edu.az"));  
            MailMessage.From = new MailAddress(email);
            MailMessage.Subject = "Your email subject";
            MailMessage.Body = string.Format(body, name,surname,email,phone,message);
            MailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential
                {
                    UserName = "elvinem@code.edu.az",
                    Password = "elvin1998"
                }
            };

            client.Send(MailMessage);


            return Json("Mesajınız uğurla göndərildi , təşəkkürlər !", JsonRequestBehavior.AllowGet);
        }
    }
}