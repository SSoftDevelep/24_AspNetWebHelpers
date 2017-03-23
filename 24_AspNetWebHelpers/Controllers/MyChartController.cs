using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace _24_AspNetWebHelpers.Controllers
{
    public class MyChartController : Controller
    {
        // GET: MyChart
        public ActionResult ChartGoster()
        {
            return View();
        }

        public ActionResult ChartOlustur(string tip = "Column", string cache = "chart1")
        {
            Chart chart = Chart.GetFromCache(cache);  //resmi cacheden okuduk.
            if (chart == null)
            {
                chart = new Chart(500, 500);
                chart.AddTitle("MyComputer-Urun Satis Detay Grafigi");
                chart.AddLegend("Ürünler");
                chart.AddSeries(name: "Bilgisayar A", chartType: tip,
                    xValue: new[] { 20, 40, 60 },
                    yValues: new[] { 800, 1200, 2300 });

                chart.AddSeries(name: "Bilgisayar B", chartType: tip,
                   xValue: new[] { 20, 40, 60 },
                   yValues: new[] { 900, 1600, 3500 });

                string dir = Server.MapPath("~/charts/");

                if (Directory.Exists(dir) == false)  //directory altinda charts klasoru yoksa olusturuyoruz.
                {
                    Directory.CreateDirectory(dir);
                }

                string imgPath = dir + "chart1.jpeg";
                string xmlPath = dir + "chart1.xml";

                chart.Save(imgPath, format:"png"); //resim dosyasi olarak kaydettik.
                chart.SaveXml(xmlPath);    //xml dosyasi olarak kaydettik.
                chart.SaveToCache(cache, 1, true);  //resmi cache'e attik. 1 dk sonra cache'de tutulur.
            }


            return View(chart);
        }

        public ActionResult ChartOlustur2(string tip = "Pie" ,string cache="chart2")
        {
            Chart chart = Chart.GetFromCache(cache);  //resmi cacheden okuduk.
            if (chart == null)
            {
                chart = new Chart(500, 500);
                chart.AddTitle("MyComputer-Urun Satis Detay Grafigi");
                chart.AddLegend("Ürünler");
                chart.AddSeries(name: "Ürünler", chartType: tip,
                    xValue: new[] { "Bilgisayar", "Fare", "Klavye" },
                    yValues: new[] { 100, 500, 300 });

                string dir = Server.MapPath("~/charts/");

                if (Directory.Exists(dir) == false)  //directory altinda charts klasoru yoksa olusturuyoruz.
                {
                    Directory.CreateDirectory(dir);
                }

                string imgPath = dir + "chart2.jpeg";
                string xmlPath = dir + "chart2.xml";

                chart.Save(imgPath, format:"png"); //resim dosyasi olarak kaydettik.
                chart.SaveXml(xmlPath);    //xml dosyasi olarak kaydettik.
                chart.SaveToCache(cache, 1, true);  //resmi cache'e attik. 1 dk sonra cache'de tutulur.
            }


            return View("ChartOlustur", chart);

        }
    }
}