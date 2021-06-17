using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcYeniKale1.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        KaleMobilya ctx = new KaleMobilya();
        public ActionResult Cari(int id)
        {
            Kisi kisiCari = ctx.Kisi.FirstOrDefault(x => x.KisiID == id);
            ViewBag.ListeCari = ctx.Cari.Where(x => x.KisiID == id).OrderByDescending(x => x.Tarih).ToList();

            ViewBag.AlacakToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 1).Sum(x => x.Tutar);
            if (ViewBag.AlacakToplam == null)
            {
                ViewBag.AlacakToplam = 0;
            }
            ViewBag.AlindiToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 2).Sum(x => x.Tutar);
            if (ViewBag.AlindiToplam == null)
            {
                ViewBag.AlindiToplam = 0;
            }
            ViewBag.BorcToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 3).Sum(x => x.Tutar);
            if (ViewBag.BorcToplam == null)
            {
                ViewBag.BorcToplam = 0;
            }
            ViewBag.OdendiToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 4).Sum(x => x.Tutar);
            if (ViewBag.OdendiToplam == null)
            {
                ViewBag.OdendiToplam = 0;
            }

            ViewBag.KalanBorc = ViewBag.BorcToplam - ViewBag.OdendiToplam;

            ViewBag.GiderToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 5).Sum(x => x.Tutar);
            if (ViewBag.GiderToplam == null)
            {
                ViewBag.GiderToplam = 0;
            }
            ViewBag.BilgiToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 6).Sum(x => x.Tutar);
            if (ViewBag.BilgiToplam == null)
            {
                ViewBag.BilgiToplam = 0;
            }
            ViewBag.MesaiToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 7).Sum(x => x.Tutar);
            if (ViewBag.MesaiToplam == null)
            {
                ViewBag.MesaiToplam = 0;
            }
            ViewBag.GelirToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 8).Sum(x => x.Tutar);
            if (ViewBag.GelirToplam == null)
            {
                ViewBag.GelirToplam = 0;
            }
            ViewBag.IskontoToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 9).Sum(x => x.Tutar);            
            if (ViewBag.IskontoToplam == null)
            {
                ViewBag.IskontoToplam = 0;
            }

            ViewBag.KalanAlacak = ViewBag.AlacakToplam - ViewBag.AlindiToplam - ViewBag.IskontoToplam;

            ViewBag.OdemeToplam = ctx.Cari.Where(x => x.KisiID == id && x.DurumID == 10).Sum(x => x.Tutar);
            if (ViewBag.OdemeToplam == null)
            {
                ViewBag.OdemeToplam = 0;
            }

            return View(kisiCari);
        }

        public ActionResult CariGuncelle(int id)
        {
            Cari cg = ctx.Cari.FirstOrDefault(x => x.CariID == id);
            ViewBag.Durumlar = ctx.Durum.ToList();
            return View(cg);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cari cg, byte cDId, decimal cTutar, DateTime cTarih, string cAciklama, int KisiID)
        {
            Cari cariguncelle = ctx.Cari.FirstOrDefault(x => x.CariID == cg.CariID);

            cariguncelle.DurumID = cDId;
            cariguncelle.Tutar = cTutar;
            cariguncelle.Tarih = cTarih;
            cariguncelle.Aciklama = cAciklama;

            ctx.SaveChanges();

            return RedirectToAction("Cari", new { id = KisiID });
        }

        
        public ActionResult CariSil(int id)
        {
            Cari cs = ctx.Cari.FirstOrDefault(x => x.CariID == id);
            ctx.Cari.Remove(cs);
            ctx.SaveChanges();
            var KisiID = cs.KisiID;
            return RedirectToAction("Cari", new { id = KisiID });
        }

        public ActionResult CariEkle(int id)
        {
            Kisi kisiCari = ctx.Kisi.FirstOrDefault(x => x.KisiID == id);
            ViewBag.Durumlar = ctx.Durum.ToList();
            return View(kisiCari);
        }

        [HttpPost]
        public ActionResult CariEkle(int KisiID, byte cDId, decimal cTutar, DateTime cTarih, string cAciklama)
        {
            Cari Cari = new Cari();

            Cari.KisiID = KisiID;
            Cari.DurumID = cDId;
            Cari.Tutar = cTutar;
            Cari.Tarih = cTarih;
            Cari.Aciklama = cAciklama;

            ctx.Cari.Add(Cari);
            ctx.SaveChanges();

            return RedirectToAction("Cari",new {id=KisiID });
        }
    }
}