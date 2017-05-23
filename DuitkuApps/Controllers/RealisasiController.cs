using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuitkuApps.Models;
using DuitkuApps.DAL;

namespace DuitkuApps.Controllers
{
    public class RealisasiController : Controller
    {
        // GET: Realisasi
        public ActionResult TampilRealisasi()
        {
            using (RealisasiDAL tampil = new RealisasiDAL())
            {
                var result = tampil.AmbilDataRealisasi().ToList();
                if (TempData["Pesan"] != null)
                {
                    ViewBag.Pesan = TempData["Pesan"].ToString();
                }
                return View(result);
            }
        }

        public ActionResult TambahRealisasi()
        {
            var lstKomponen = new List<SelectListItem>();

            using (RealisasiDAL data = new RealisasiDAL())
            {
                foreach (var kec in data.AmbilDataKomponen())
                {
                    lstKomponen.Add(new SelectListItem
                    {
                        Value = kec.Id_komponen.ToString(),
                        Text = kec.Nama_komponen
                    });
                }
                ViewBag.Pengeluaran = lstKomponen;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TambahRealisasi(Realisasi tmbh)
        {

            using (RealisasiDAL data = new RealisasiDAL())
            {
                try
                {
                    data.TambahRealisasi(tmbh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                        "success", "Data Pengeluaran " + tmbh.Nama_realisasi + " berhasil ditambah");
                    return RedirectToAction("TampilRealisasi");
                }
                catch
                {
                    return View();
                }
            }
        }


        [Authorize]
        public ActionResult EditRealisasi(int id)
        {
            using (RealisasiDAL ubah = new RealisasiDAL())
            {
                var data = ubah.TampilIDReal(id);
                return View(data);
            }
        }

        [HttpPost, ActionName("EditRealisasi")]
        [ValidateAntiForgeryToken]
        public ActionResult EditRealisasi(Realisasi ubh)
        {
            using (RealisasiDAL data = new RealisasiDAL())
            {
                try
                {
                    data.UbahRealisasi(ubh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                       "success", "Data Komponen " + ubh.Nama_realisasi + " berhasil dirubah");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("TampilRealisasi");
        }

        public ActionResult DeleteRealisasi(int? id)
        {
            if (id != null)
            {
                using (RealisasiDAL data = new RealisasiDAL())
                {
                    try
                    {
                        data.HapusRealisasi(id.Value);
                        TempData["Pesan"] = Pesan.GetPesan("Sukses !", "success", "Data Realisasi  berhasil dihapus");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
            return RedirectToAction("TampilRealisasi");
        }

        public ActionResult Cari(DateTime? dari, DateTime? ke)
        {
            using (RealisasiDAL tgl = new RealisasiDAL())
            {
                ViewBag.dari = dari;
                ViewBag.ke = ke;
                var results = tgl.CariTanggal(dari, ke).ToList();
                return View("TampilRealisasi", results);
            }
        }
    }
}