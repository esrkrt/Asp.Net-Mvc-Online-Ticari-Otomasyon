using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle(text: " Kategoriler-Ürün Stok Sayısı").AddLegend( "Stok").AddSeries(
           "Değerler",
                xValue: new[] { "Beyaz Eşya", "Televizyon", "Bilgisayar", "Küçük Ev Aletleri" },
                yValues: new[] { 500, 250, 340, 620 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
    }
}