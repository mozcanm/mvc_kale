using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYeniKale1.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        KaleMobilya ctx = new KaleMobilya();
        public ActionResult Kisi()
        {
            //List<Kisi> kisiler = ctx.Kisi.ToList();
            ViewBag.ListeKisi = ctx.Kisi.OrderBy(x=>x.Ad).ToList();

            //View e Model metodu ile gönder
            //return View(kisiler);
            return View();
        }

        public ActionResult KisiSil(int id)
        {
            Kisi kisisil = ctx.Kisi.FirstOrDefault(x => x.KisiID == id);
            return View(kisisil);
        }

        [HttpPost]
        public ActionResult KisiSil(Kisi k)
        {
            Kisi ks = ctx.Kisi.FirstOrDefault(x => x.KisiID == k.KisiID);
            var cs = ctx.Cari.Where(id => id.KisiID == k.KisiID);
            ctx.Cari.RemoveRange(cs);
            ctx.Kisi.Remove(ks);
            ctx.SaveChanges();
            return RedirectToAction("Kisi");
        }

        public ActionResult KisiGuncelle(int id)
        {
            Kisi kg = ctx.Kisi.FirstOrDefault(x=>x.KisiID == id);
            return View(kg);
        }

        [HttpPost]
        public ActionResult KisiGuncelle(Kisi kg, string kAd, string kFirma, string kTel1, string kTel2, string kAdres)
        {
            Kisi kisiguncelle = ctx.Kisi.FirstOrDefault(x => x.KisiID == kg.KisiID);

            kisiguncelle.Ad = kAd;
            kisiguncelle.Firma = kFirma;
            kisiguncelle.Tel1 = kTel1;
            kisiguncelle.Tel2 = kTel2;
            kisiguncelle.Adres = kAdres;

            ctx.SaveChanges();

            return RedirectToAction("Kisi");
        }

        public ActionResult KisiEkle()
        {
            List<Kisi> kisiler = ctx.Kisi.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult KisiEkle(string kisiAd, string kisiFirma, string kisiTel1, string kisiTel2, string kisiAdres) {
            Kisi kisi = new Kisi();

            kisi.Ad = kisiAd;
            kisi.Firma = kisiFirma;
            kisi.Tel1 = kisiTel1;
            kisi.Tel2 = kisiTel2;
            kisi.Adres = kisiAdres;

            ctx.Kisi.Add(kisi);
            ctx.SaveChanges();

            return RedirectToAction("Kisi");
        }
    }
}