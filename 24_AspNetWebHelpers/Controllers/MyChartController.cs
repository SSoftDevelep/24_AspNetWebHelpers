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

        public ActionResult ChartOlustur(string tip = "Column")
        {
            Chart chart = Chart.GetFromCache("chart1");  //resmi cacheden okuduk.
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

                chart.Save(imgPath, "png"); //resim dosyasi olarak kaydettik.
                chart.SaveXml(xmlPath);    //xml dosyasi olarak kaydettik.
                chart.SaveToCache("chart1", 1, true);  //resmi cache'e attik. 1 dk sonra cache'de tutulur.
            }


            return View(chart);
        }
    }
}