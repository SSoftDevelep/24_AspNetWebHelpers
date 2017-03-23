using System;
using System.Collections.Generic;
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

        public ActionResult ChartOlustur(string tip ="Column")
        {

            Chart chart = new Chart(500, 500);
            chart.AddTitle("MyComputer-Urun Satis Detay Grafigi");
            chart.AddLegend("Ürünler");
            chart.AddSeries(name: "Bilgisayar A", chartType: tip,
                xValue: new[] { 20, 40, 60 }, yValues: new[] { 800, 1200, 2300 });

            chart.AddSeries(name: "Bilgisayar B", chartType: tip,
               xValue: new[] { 20, 40, 60 }, yValues: new[] { 900, 1600, 3500 });

            chart.Write();

            return View(chart);
        }
    }
}