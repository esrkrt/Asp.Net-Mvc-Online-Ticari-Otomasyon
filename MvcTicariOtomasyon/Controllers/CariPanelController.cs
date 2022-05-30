using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degreler = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.Cariid).FirstOrDefault(); 
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.CariID == mailid).Count();
            ViewBag.tplamsatis = toplamsatis;

            var toplamtutar = c.SatisHarekets.Where(x => x.CariID == mailid).Sum(y => y.ToplamTutar);
            ViewBag.toplamtutar = toplamtutar;
            var toplamurunsayisi= c.SatisHarekets.Where(x => x.CariID == mailid).Sum(y => y.Adet);
            ViewBag.toplamurunsayisi = toplamurunsayisi;

            var adsoyad = c.Carilers.Where(cari => cari.CariMail == mail).Select(y => y.CariAd+ " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad= adsoyad;

            var sehir = c.Carilers.Where(cari => cari.CariMail == mail).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.sehir = sehir;
            return View(degreler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.Cariid).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();

            return View(degerler);
        }
        public ActionResult IncomingMessages()
        {
            var mail = (string)Session["CariMail"];
            var messages = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.Id).ToList();
            var messageCount = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.messageCount = messageCount;
            var OutgoingMessages = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
           ViewBag.OutgoingMessages = OutgoingMessages;
            return View(messages);
        }
        public ActionResult OutgoingMessages()
        {
            var mail = (string)Session["CariMail"];
            var messages = c.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(x => x.Id).ToList();
            var OutgoingMessages = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            var messageCount = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.messageCount = messageCount;
            return View(messages);
        }
        public ActionResult MessageDetail(int id)
        {
            var value = c.Mesajlars.Where(x => x.Id == id).ToList();
            var mail = (string)Session["CariMail"];
            var OutgoingMessages = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            var messageCount = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.messageCount = messageCount;
            return View(value);
        }
        public ActionResult MessageDetail2(int id)
        {
            var value = c.Mesajlars.Where(x => x.Id == id).ToList();
            var mail = (string)Session["Email"];
            var OutgoingMessages = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            var messageCount = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.messageCount = messageCount;
            return View(value);
        }

        [HttpGet]
        public ActionResult NewMessages()
        {
            var mail = (string)Session["CariMail"];
            var OutgoingMessages = c.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.OutgoingMessages = OutgoingMessages;
            var messageCount = c.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.messageCount = messageCount;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessages(Mesajlar messages)
        {
            var mail = (string)Session["CariMail"];
            messages.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            messages.Gonderici = mail;
            c.Mesajlars.Add(messages);
            c.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string p)
        {
            var cargo = from x in c.KargoDetays select x;
            cargo = cargo.Where(y => y.TakipKodu.Contains(p));
            return View(cargo.ToList());
          
        }
        public ActionResult KargoDetay(string id)
        {
            Context context = new Context();
            var result = c.KargoTakips.Where(personel => personel.TakipKodu == id).ToList();

            return View(result);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Settings() //ayarlar
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(cari => cari.CariMail == mail).Select(x => x.Cariid).FirstOrDefault();
            var cariSearch = c.Carilers.Find(id);
            return PartialView("Settings", cariSearch);

        }
        public PartialViewResult Announs()//Duyurular
        {
            var value = c.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(value);
        }
        public ActionResult Update(Cariler cari)
        {
            var value = c.Carilers.Find(cari.Cariid);
            value.CariAd= cari.CariAd;
            value.CariSoyad = cari.CariSoyad;
            value.CariSifre = cari.CariSifre;
            value.CariSehir= cari.CariSehir;
            value.CariMail = cari.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}