using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _24_AspNetWebHelpers.Controllers
{
    public class MyCriptoController : Controller
        
    {
        private string sifresizMetin = "Mazhar Fuat Ozkan";
        private string sifreliMetin= "AHmvexys1/X04+hkewcdrZ+FXSJGWbZ3GYPBdmOYM2f6jwgrynxHdprtDm7JoZzijQ==";
        // GET: MyCripto
        public ActionResult Index()
        {
            string salt = Crypto.GenerateSalt(); //random anahtar deger uretilir.
            string hash = Crypto.Hash(sifresizMetin,algorithm:"md5");  //sh defaultta sh256'a gore calisir. Ayni deger uretir.
            string sh1 = Crypto.SHA1(sifresizMetin);
            string sh256 = Crypto.SHA256(sifresizMetin);

            string sonuc = Crypto.HashPassword(sifresizMetin);
            bool dogruMu = Crypto.VerifyHashedPassword(sifreliMetin, sifresizMetin);

            return View();
        }
    }
}