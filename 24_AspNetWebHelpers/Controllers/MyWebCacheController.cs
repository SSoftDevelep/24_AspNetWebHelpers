using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _24_AspNetWebHelpers.Controllers
{
    public class MyWebCacheController : Controller
    {
        // GET: MyWebCache
        public ActionResult Index()
        {
            string time = WebCache.Get("zaman");  //zaman anahtarinin icindeki degeri getir.

            if (string.IsNullOrEmpty(time))
            {
                time = DateTime.Now.ToString();
                WebCache.Set(key: "zaman", value: time, minutesToCache: 1, slidingExpiration: true);
            }
            ViewBag.Simdi = time;

            return View();
        }

        public ActionResult RemoveCache()
        {
            WebCache.Remove("zaman");
            return RedirectToAction("Index");
        }
    }
}