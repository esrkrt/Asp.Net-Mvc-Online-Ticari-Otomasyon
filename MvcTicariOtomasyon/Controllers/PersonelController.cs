using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departmanlar = (from x in c.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmaAd,
                                                     Value = x.Departmanid.ToString()
                                                 }).ToList();
            ViewBag.dprtmn = departmanlar;

            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/İmage/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel= "/İmage/" + dosyaadi + uzanti;

            }
            p.Durum = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departmanlar = (from x in c.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmaAd,
                                                     Value = x.Departmanid.ToString()
                                                 }).ToList();
            ViewBag.dprtmn = departmanlar;

            var personel = c.Personels.Find(id);
            return View("PersonelGetir", personel);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
             if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/İmage/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel= "/İmage/" + dosyaadi + uzanti;

            }
            var personel = c.Personels.Find(p.PersonelID);

            personel.PersonelAd = p.PersonelAd;
            personel.PersonelSoyad = p.PersonelSoyad;
            personel.PersonelGorsel = p.PersonelGorsel;
            personel.DepartmanID = p.DepartmanID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = c.Personels.Find(id);
            personel.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}