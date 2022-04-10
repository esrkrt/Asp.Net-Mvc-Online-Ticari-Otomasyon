using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {

        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var departmanlar = c.Departmans.Where(x => x.Durum == true).ToList();
            return View(departmanlar);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}