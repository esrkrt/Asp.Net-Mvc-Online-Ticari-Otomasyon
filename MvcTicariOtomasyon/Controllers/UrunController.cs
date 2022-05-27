using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urn = c.Uruns.Find(id);
            urn.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> kategoriler = (from x in c.Kategoris.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.KategoriAd,
                                                    Value = x.KategoriID.ToString()
                                                }).ToList();
            ViewBag.ktgr = kategoriler;

            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir", urundeger);
        }
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunID);

            urn.AlisFiyat = u.AlisFiyat;
            urn.Durum = u.Durum;
            urn.KategoriID = u.KategoriID;
            urn.Marka = u.Marka;
            urn.SatisFiyat = u.SatisFiyat;
            urn.Stok = u.Stok;
            urn.UrunAd = u.UrunAd;
            urn.UrunGorsel = u.UrunGorsel;

            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunListesi()
        {
            var urunler = c.Uruns.ToList();
            return View(urunler);
        }
    }
}