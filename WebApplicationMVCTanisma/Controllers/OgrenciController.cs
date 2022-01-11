using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCTanisma.Models;

namespace WebApplicationMCVTanisma.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        public ActionResult Listele()
        {
            List<Ogrenci> ogrList = Ogrenci.OgrencileriGetir();
            return View(ogrList);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Ogrenci ogr)
        {
            //Veritabanımız olmadığı için id'yi kendimiz atama amaçlı bu satırlara yazdık.
            var tumOgrler = Ogrenci.OgrencileriGetir();
            ogr.Id = tumOgrler.Count + 1;

            //Öğrenciyi Ekleyelim
            Ogrenci.OgrenciListesi.Add(ogr);
            //Ekleme yapıldıktan sonra Listele Action'ına redirect olalım.
            return RedirectToAction("Listele");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            // gelen id>0 ise benim listemde onu bul ve View'e gönder
            if (id>0)
            {
                Ogrenci bulunanOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == id);
                return View(bulunanOgr);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Guncelle(Ogrenci ogr)
        {
            Ogrenci guncellenecekEskiOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == ogr.Id);
            if (guncellenecekEskiOgr!=null)
            {
                //Öğrenciyi buldun. Bulduğun bu öğrenciye yeni değerlerini ata...
                // guncellenecekEskiOgr.Ad = ogr.Ad;
                // = işaretinin sağında Güncelle sayfasına girdiğimiz bilgiyi aldık ve bizdeki mevcut öğrenciye atadık.
                guncellenecekEskiOgr.Ad = ogr.Ad;
                guncellenecekEskiOgr.Soyad = ogr.Soyad;
                guncellenecekEskiOgr.DogumTarihi = ogr.DogumTarihi;
            }
            return RedirectToAction("Listele");
        }
        [HttpGet]
        public ActionResult Sil(int id)
        {
            var silinecekOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == id);
            return View(silinecekOgr);
        }
        [HttpPost]
        public ActionResult Sil(Ogrenci ogr)
        {
            if (ogr.Id>0)
            {
                Ogrenci.OgrenciListesi.Remove(ogr);
            }
            return RedirectToAction("Listele");
        }
        [HttpPost]
        public ActionResult Sil2(Ogrenci ogr)
        {
            if (ogr.Id>0)
            {
                Ogrenci.OgrenciListesi.Remove(ogr);
                return Json(new { success = true });
            }
            return Json(new { success = false, error = "Beklenmedik bir hata oluştu!" });
        }
    }
}