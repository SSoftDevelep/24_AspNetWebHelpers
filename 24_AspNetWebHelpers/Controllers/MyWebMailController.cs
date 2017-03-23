using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _24_AspNetWebHelpers.Controllers
{
    public class MyWebMailController : Controller
    {
        // GET: MyWebMail
        public ActionResult Index()
        {
            bool sonuc = false;

            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.UserName = "emre.solmaz106@gmail.com";
            WebMail.Password = "bednam2018";

            WebMail.EnableSsl = true;

            string file = Server.MapPath("~/Images/sait.jpg");

            try
            {
                WebMail.Send(
                    to: "emresolmaz@outlook.com", subject: "Web Mail Test",
                    body: "Bu bir web mail denemesidir.<br><b>Lütfen dikkate almayınız..</b>",
                    replyTo: "dont-reply@outlook.com", isBodyHtml: true,
                    filesToAttach: new[] { file });

                sonuc = true;
            }
            catch (Exception ex)
            {
                ViewBag.Hata = ex.Message;
            }

            ViewBag.Sonuc = sonuc;

            return View();
            
        }
    }
}