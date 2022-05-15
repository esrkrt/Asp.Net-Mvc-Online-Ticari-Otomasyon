using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class UrunDetayiController : Controller
    {
        // GET: UrunDetayi
        Context c = new Context();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            // var degerler = c.Uruns.Where(x => x.UrunID == 1).ToList();
            cs.Deger1= c.Uruns.Where(x => x.UrunID == 1).ToList();
            cs.Deger2= c.Detays.Where(y => y.DetayID == 1).ToList();


            return View(cs);
        }
    }
}