using _24_AspNetWebHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _24_AspNetWebHelpers.Controllers
{
    public class AntiForgeryController : Controller
    {
        
        public ActionResult Test()
        {
            return View(Veritabani.veriler);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]  //olusturalan kodun kontrolunu saglariz.eslesme dogru olursa post olur.
        public ActionResult Test(int id)
        {
            Veritabani.veriler.RemoveAt(id);
            return RedirectToAction("Test");
        }

        public ActionResult FakeTest()
        {
            return View();
        }
    }
}