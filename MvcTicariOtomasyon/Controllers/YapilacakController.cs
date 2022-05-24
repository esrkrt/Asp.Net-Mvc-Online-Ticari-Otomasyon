using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.cari = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.urun = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.ktg = deger3;
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.sehir = deger4;
            var yapilacaklar = c.Yapilacaks.ToList();
            return View(yapilacaklar);
        }
    }
}