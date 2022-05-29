using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var degreler = c.Carilers.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.m = mail;
            
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


    }
}