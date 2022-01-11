using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCTanisma.Models;

namespace WebApplicationMVCTanisma.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var ogrData = Ogrenci.OgrencileriGetir();
            return View(ogrData);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            if (id>0)
            {
                var ogr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == id);
                return View(ogr);
            }
            return View("Error");
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Ogrenci ogr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Eğer Tüm Parametreler doğruysa buraya gir.
                    // TODO: Add insert logic here
                    ogr.Id = Ogrenci.OgrenciListesi.Count + 1;
                    Ogrenci.OgrenciListesi.Add(ogr);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            if (id>0)
            {
                var ogr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == id);
                return View(ogr);

            }
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Ogrenci ogr)
        {
            try
            {
                if (!ModelState.IsValid) //Model geçerli olamadıysa, yani model istenilen validasyonları sağlayamadıysa
                {
                    return View();
                }
                // TODO: Add update logic here
                if (ogr.Id>0)
                {
                    var eskiOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == ogr.Id);
                    eskiOgr.Ad = ogr.Ad;
                    eskiOgr.Soyad = ogr.Soyad;
                    eskiOgr.DogumTarihi = ogr.DogumTarihi;
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var ogr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == id);
                return View(ogr);

            }
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(Ogrenci ogr)
        {
            try
            {
                if (ogr.Id>0)
                {
                    Ogrenci.OgrenciListesi.Remove(ogr);
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
