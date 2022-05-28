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
                Urunad = "Bilgisayar",
                Stok = 120
            });
            snf.Add(new Sınıf1()
            {
                Urunad = "Beyaz Eşya",
                Stok = 150
            });
            snf.Add(new Sınıf1()
            {
                Urunad = "Mobilya",
                Stok = 70
            });
            snf.Add(new Sınıf1()
            {
                Urunad = "Küçük Ev Aletleri",
                Stok = 100
            });
            snf.Add(new Sınıf1()
            {
                Urunad = "Mobil Cihazlar",
                Stok = 90
            });
            snf.Add(new Sınıf1()
            {
                Urunad = "Tablet",
                Stok = 200
            });
            return snf;
        }

        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);

        }
        public List<Sınıf2> UrunListesi2()
        {
            List<Sınıf2> snf = new List<Sınıf2>();
            using (var context = new Context())
            {
                snf = context.Uruns.Select(x => new Sınıf2
                {
                    Urn = x.UrunAd,
                    Stk = x.Stok
                }).ToList();
            }
            return snf;

        }
    }
}