using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Email.Models;
using System.Net;
using System.Net.Mail;

namespace Email.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(Email.Models.gmail model)
        
        {
            
            {

                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("roshan.bajracharya00@gmail.com");
                mm.To.Add(model.To);
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                //smtp.EnableSsl = smtp.Port == 587 || smtp.Port == 465;
                smtp.EnableSsl = true;



                NetworkCredential nc = new NetworkCredential("roshan.bajracharya00@gmail.com", "dharan@123");
                smtp.UseDefaultCredentials = true ;

                smtp.Credentials = nc;
                smtp.Send(mm);
                ViewBag.Message = "Mail Has Been Sent Successfully !";

                return View();
            }
          
           
        }
    }
}