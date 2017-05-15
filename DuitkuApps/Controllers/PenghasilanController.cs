using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuitkuApps.Models;
using DuitkuApps.DAL;
using DuitkuApps.ViewModels;
using System.Globalization;

namespace DuitkuApps.Controllers
{
    public class PenghasilanController : Controller
    {
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    Session["username"] = User.Identity.Name;
                }
                else
                {
                    var tempUser = Guid.NewGuid().ToString();
                    Session["username"] = tempUser;
                }
            }
            using (PenghasilanDAL tampil = new PenghasilanDAL())
            { 
                var result = tampil.Tampil().ToList();
                if (TempData["Pesan"] != null)
                {
                    ViewBag.Pesan = TempData["Pesan"].ToString();
                }
                return View(result);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Penghasilan tmbh)
        {
            using (PenghasilanDAL data = new PenghasilanDAL())
            {
                try
                {
                    data.Tambah(tmbh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                        "success", "Data Penghasilan " + tmbh.Nama_penghasilan + " berhasil ditambah");
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            using (PenghasilanDAL ubah = new PenghasilanDAL())
            {
                var data = ubah.TampilByID(id);
                return View(data);
            }
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Penghasilan ubh)
        {
            using (PenghasilanDAL data = new PenghasilanDAL())
            {
                try
                {
                    data.Ubah(ubh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                       "success", "Data Komponen " + ubh.Nama_penghasilan + " berhasil dirubah");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }

      
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                using (PenghasilanDAL data = new PenghasilanDAL())
                {
                    try
                    {
                        data.HapusData(id.Value);
                        TempData["Pesan"] = Pesan.GetPesan("Sukses !", "success", "Data Komponen  berhasil dihapus");
                    }
                    catch
                    {
                        return View();
                    }   
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Cari(DateTime? dari, DateTime? ke)
        {
            using (PenghasilanDAL tgl = new PenghasilanDAL())
            {
                if (!dari.HasValue) dari = DateTime.Now.Date;
                if (!ke.HasValue) ke = dari.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                if (ke < dari) ke = dari.GetValueOrDefault(DateTime.Now.Date).Date.AddDays(1);
                ViewBag.dari = dari;
                ViewBag.ke = ke;
                var results = tgl.Filter(dari, ke).ToList();
                return View(results);
            }
        }


    }
}

