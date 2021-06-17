using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
public class MaliViewModel
{
    public int mKisiID { get; set; }
    public String mSonTarih { get; set; }
    public String mSonTarih2 { get; set; }
    public String mAd { get; set; }
    public String mTelefon { get; set; }
    public decimal mBakiye { get; set; }
    public decimal mAlindi { get; set; }
    public decimal mOdendi { get; set; }
    public decimal mAlacagim { get; set; }
    public decimal mBorcum { get; set; }
}

namespace MvcYeniKale1.Controllers
{   
    public class MaliController : Controller
    {

        // GET: Mali
        KaleMobilya ctx = new KaleMobilya();
        public ActionResult Alacak()
        {         
            MaliViewModel mali = new MaliViewModel();

            var alacagim = from kisiler in ctx.Kisi
                           join cariler in ctx.Cari on kisiler.KisiID equals cariler.KisiID
                           join durumlar in ctx.Durum on cariler.DurumID equals durumlar.DurumID

                           group cariler by new { cariler.KisiID, kisiler.Ad, kisiler.Tel1 } into grup
                           let KisiID = grup.Key.KisiID
                           let Ad = grup.Key.Ad
                           let Telefon = grup.Key.Tel1
                           let SonTarih2 = grup.Where(x => x.DurumID == 1).Max(x => x.Tarih)
                           let SonTarih = grup.Where(x => x.DurumID == 2).Max(x => x.Tarih)
                           let Bakiye = grup.Where(x => x.DurumID == 1).Sum(x => (decimal?)x.Tutar) ?? 0
                           let Alindi = grup.Where(x => x.DurumID == 2).Sum(x => (decimal?)x.Tutar) ?? 0
                           let iskonto = grup.Where(x => x.DurumID == 9).Sum(x => (decimal?)x.Tutar) ?? 0
                           let Alacagim = (Bakiye - (Alindi + iskonto))
                           
                           orderby grup.Key.Ad
                           select new MaliViewModel
                           {
                               mKisiID = KisiID,
                               mSonTarih=SonTarih.ToString(),
                               mSonTarih2 = SonTarih2.ToString(),
                               mAd =Ad,
                               mTelefon=Telefon,
                               mBakiye=Bakiye,
                               mAlindi=Alindi,
                               mAlacagim=Alacagim
                           };

            return View(alacagim);
        }

        public ActionResult Borc()
        {
            MaliViewModel mali = new MaliViewModel();

            var borcum = from kisiler in ctx.Kisi
                           join cariler in ctx.Cari on kisiler.KisiID equals cariler.KisiID
                           join durumlar in ctx.Durum on cariler.DurumID equals durumlar.DurumID

                           group cariler by new { cariler.KisiID, kisiler.Ad, kisiler.Tel1 } into grup
                           let KisiID = grup.Key.KisiID
                           let Ad = grup.Key.Ad
                           let Telefon = grup.Key.Tel1
                           let Bakiye = grup.Where(x => x.DurumID == 3).Sum(x => (decimal?)x.Tutar) ?? 0
                           let Odendi = grup.Where(x => x.DurumID == 4).Sum(x => (decimal?)x.Tutar) ?? 0
                           let Borcum = (Bakiye - Odendi)

                           orderby grup.Key.Ad
                           select new MaliViewModel
                           {
                               mKisiID = KisiID,
                               mAd = Ad,
                               mTelefon = Telefon,
                               mBakiye = Bakiye,
                               mOdendi = Odendi,
                               mBorcum = Borcum
                           };

            return View(borcum);
        }
    }   
}