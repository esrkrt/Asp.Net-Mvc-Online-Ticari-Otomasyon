using MvcTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
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
            grafikciz.AddTitle(text: " Kategoriler-Ürün Stok Sayısı").AddLegend("Stok").AddSeries(
           "Değerler",
                xValue: new[] { "Beyaz Eşya", "Televizyon", "Bilgisayar", "Küçük Ev Aletleri" },
                yValues: new[] { 500, 250, 340, 620 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        Context c = new Context();
        public ActionResult Index3()
        {

            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800).AddTitle(
                "Stoklar").AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");

        }

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);

        }
        public List<Sınıf1> UrunListesi()
        {
            List<Sınıf1> snf = new List<Sınıf1>();
            snf.Add(new Sınıf1()
            {
                Uurunad = "Bilgisayar",
                Stok = 120
            });
            snf.Add(new Sınıf1()
            {
                Uurunad = "Beyaz Eşya",
                Stok = 150
            });
            snf.Add(new Sınıf1()
            {
                Uurunad = "Mobilya",
                Stok = 70
            });
            snf.Add(new Sınıf1()
            {
                Uurunad = "Küçük Ev Aletleri",
                Stok = 100
            });
            snf.Add(new Sınıf1()
            {
                Uurunad = "Mobil Cihazlar",
                Stok = 90
            });
            snf.Add(new Sınıf1()
            {
                Uurunad = "Tablet",
                Stok = 200
            });
            return snf;
        }
    }

}