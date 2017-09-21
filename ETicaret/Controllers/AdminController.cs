using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.App_Classes;
using ETicaret.Models;
using System.Drawing;
using System.Configuration;
using System.IO;
using System.Text;

namespace ETicaret.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Urunler()
        {
            return View(Contex.Baglanti.Uruns.ToList());
        }

        public ActionResult UrunEkle()
        {
           
                ViewBag.Kategoriler = Contex.Baglanti.Kategoris.ToList();
                ViewBag.Markalar = Contex.Baglanti.Markas.ToList();
                return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urn)
        {
            Contex.Baglanti.Uruns.Add(urn);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("Urunler");
        }

        public ActionResult UrunSil(int urunId)
        {
            Urun u = Contex.Baglanti.Uruns.FirstOrDefault(x => x.Id == urunId);
            Contex.Baglanti.Uruns.Remove(u);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("Urunler");
        }

        public ActionResult Markalar()
        {
            return View(Contex.Baglanti.Markas.ToList());
        }

        public ActionResult MarkaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MarkaEkle(Marka mrk, HttpPostedFileBase fileUpload)
        {
            int resimId = 0;
            if (fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                int width = Convert.ToInt32(ConfigurationManager.AppSettings["MarkaWidth"].ToString());
                int height = Convert.ToInt32(ConfigurationManager.AppSettings["MarkaHeight"].ToString());

                string name = "/Content/MarkaResim/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                Bitmap bm = new Bitmap(img, width, height);

                bm.Save(Server.MapPath(name));

                Resim rsm = new Resim();
                rsm.OrtaYol = name;
                Contex.Baglanti.Resims.Add(rsm);
                Contex.Baglanti.SaveChanges();

                if (rsm.Id != 0)
                {
                    resimId = rsm.Id;
                }

                if (resimId != -1)
                    mrk.ResimID = resimId;
                Contex.Baglanti.Markas.Add(mrk);
                Contex.Baglanti.SaveChanges();
            }

            return RedirectToAction("Markalar");
        }

        public ActionResult MarkaSil(int markaId)
        {
            Marka mrk = Contex.Baglanti.Markas.FirstOrDefault(x => x.Id == markaId);
            Contex.Baglanti.Markas.Remove(mrk);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("Markalar");
        }

        public ActionResult Kategoriler()
        {
            return View(Contex.Baglanti.Kategoris.ToList());
        }


        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori ktg)
        {
            Contex.Baglanti.Kategoris.Add(ktg);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("Kategoriler");

        }

        public ActionResult KategoriSil(int kategoriId)
        {
            Kategori kat = Contex.Baglanti.Kategoris.FirstOrDefault(x => x.Id == kategoriId);
            Contex.Baglanti.Kategoris.Remove(kat);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("Kategoriler");
        }


        public ActionResult OzellikTipleri()
        {
            return View(Contex.Baglanti.OzellikTips);
        }

        public ActionResult OzellikTipEkle()
        {
            return View(Contex.Baglanti.Kategoris);
        }

        [HttpPost]
        public ActionResult OzellikTipEkle(OzellikTip ot)
        {
            Contex.Baglanti.OzellikTips.Add(ot);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("OzellikTipleri");
        }

        public ActionResult OzellikTipSil(int ozellikTipId)
        {
            OzellikTip ot = Contex.Baglanti.OzellikTips.FirstOrDefault(x => x.Id == ozellikTipId);
            Contex.Baglanti.OzellikTips.Remove(ot);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("OzellikTipleri");
        }

        public ActionResult OzellikDegerleri()
        {
            return View(Contex.Baglanti.OzellikDegers.ToList());
        }

        public ActionResult OzellikDegerEkle()
        {
            return View(Contex.Baglanti.OzellikTips.ToList());
        }

        [HttpPost]
        public ActionResult OzellikDegerEkle(OzellikDeger od)
        {
            Contex.Baglanti.OzellikDegers.Add(od);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("OzellikDegerleri");
        }

        public ActionResult OzellikDegerSil(int ozellikDegerId)
        {
            OzellikDeger ot = Contex.Baglanti.OzellikDegers.FirstOrDefault(x => x.Id == ozellikDegerId);
            Contex.Baglanti.OzellikDegers.Remove(ot);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("OzellikDegerleri");
        }

        public ActionResult UrunOzellikleri()
        {
            return View(Contex.Baglanti.UrunOzelliks.ToList());
        }


        public ActionResult UrunOzellikSil(int urunId, int tipId, int degerId)
        {
            UrunOzellik uo = Contex.Baglanti.UrunOzelliks.FirstOrDefault(x => x.UrunID == urunId && x.OzellikTipID == tipId && x.OzellikDegerID == degerId);
            Contex.Baglanti.UrunOzelliks.Remove(uo);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("UrunOzellikleri");
        }

        public ActionResult UrunOzellikEkle()
        {
            return View(Contex.Baglanti.Uruns.ToList());
        }

        public PartialViewResult UrunOzellikTipWidget(int? katId)
        {
            if (katId != null)
            {
                var data = Contex.Baglanti.OzellikTips.Where(x => x.KategoriID == katId).ToList();
                return PartialView(data);
            }

            else
            {
                var data = Contex.Baglanti.OzellikTips.ToList();
                return PartialView(data);
            }
        }


        public PartialViewResult UrunOzellikDegerWidget(int? tipId)
        {
            if (tipId != null)
            {
                var data = Contex.Baglanti.OzellikDegers.Where(x => x.OzellikTipID == tipId).ToList();
                return PartialView(data);
            }

            else
            {
                var data = Contex.Baglanti.OzellikDegers.ToList();
                return PartialView(data);
            }
        }

       [HttpPost]
       public ActionResult UrunOzellikEkle(UrunOzellik uo)
       {
            Contex.Baglanti.UrunOzelliks.Add(uo);
            Contex.Baglanti.SaveChanges();
            return RedirectToAction("UrunOzellikleri");
        }

        public ActionResult UrunResimEkle(int id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult UrunResimEkle(int uid,HttpPostedFileBase fileUpload)
        {
            if(fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                Bitmap ortaResim = new Bitmap(img, Settings.UrunOrtaBoyut);
                Bitmap buyukResim = new Bitmap(img, Settings.UrunBuyukBoyut);

                string ortaYol = "/Content/UrunResim/Orta/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string buyukYol = "/Content/UrunResim/Buyuk/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                ortaResim.Save(Server.MapPath(ortaYol));
                buyukResim.Save(Server.MapPath(buyukYol));

                Resim rsm = new Resim();
                rsm.OrtaYol = ortaYol;
                rsm.BuyukYol = buyukYol;
                rsm.UrunID = uid;
                if(Contex.Baglanti.Resims.FirstOrDefault(x=>x.UrunID == uid && x.Varsayılan == true) == null)
                {
                    rsm.Varsayılan = true;
                }

                else
                {
                    rsm.Varsayılan = false;
                }

                Contex.Baglanti.Resims.Add(rsm);
                Contex.Baglanti.SaveChanges();
                return View(uid);
            }
                return View(uid);
            
        }

        public ActionResult SliderResimleri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SliderResimEkle(HttpPostedFileBase fileUpload)
        {
            if(fileUpload!=null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);
                Bitmap bmp = new Bitmap(img,Settings.SliderResimBoyut);

                string yol = "/Content/SliderResim/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                bmp.Save(Server.MapPath(yol));

                Resim rsm = new Resim();
                rsm.BuyukYol = yol;
                Contex.Baglanti.Resims.Add(rsm);
                Contex.Baglanti.SaveChanges();

                
            }

            return RedirectToAction("SliderResimleri");
        }


    }

}