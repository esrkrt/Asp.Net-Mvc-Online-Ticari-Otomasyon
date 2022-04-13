using System;
using System.Collections.Generic;
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
            p.Durum = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}