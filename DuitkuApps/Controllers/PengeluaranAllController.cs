using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuitkuApps.Models;
using DuitkuApps.ViewModels;
using DuitkuApps.DAL;

namespace DuitkuApps.Controllers
{
    public class PengeluaranAllController : Controller
    {
        // GET: PengeluaranAll
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
            using (PengeluaranAllDAL tampil = new PengeluaranAllDAL())
            {
                var result = tampil.AmbilDataKomp().ToList();
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
        public ActionResult Create(Komp_Pengeluaran tmbh)
        {
            using (PengeluaranAllDAL data = new PengeluaranAllDAL())
            {
                try
                {
                    data.TambahKomp(tmbh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                        "success", "Data Komponen " + tmbh.Nama_komponen + " berhasil ditambah");
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
            using (PengeluaranAllDAL ubah = new PengeluaranAllDAL())
            {
                var data = ubah.TampilIDKomp(id);
                return View(data);
            }
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Komp_Pengeluaran ubh)
        {
            using (PengeluaranAllDAL data = new PengeluaranAllDAL())
            {
                try
                {
                    data.UbahKomp(ubh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                       "success", "Data Komponen " + ubh.Nama_komponen + " berhasil dirubah");
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
            if (id != null)
            {
                using (PengeluaranAllDAL data = new PengeluaranAllDAL())
                {
                    try
                    {
                        data.HapusKomp(id.Value);
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


        public ActionResult TampilPengeluaran()
        {
            using (PengeluaranAllDAL tampil = new PengeluaranAllDAL())
            {
                var result = tampil.AmbilDataPengeluaran().ToList();
                if (TempData["Pesan"] != null)
                {
                    ViewBag.Pesan = TempData["Pesan"].ToString();
                }
                return View(result);
            }
        }


            public ActionResult TambahDetail()
        {
            var lstKomp = new List<SelectListItem>();

            using (PengeluaranAllDAL data = new PengeluaranAllDAL())
            {
                foreach (var kec in data.AmbilDataKomp())
                {
                    lstKomp.Add(new SelectListItem
                    {
                        Value = kec.Id_komponen.ToString(),
                        Text = kec.Nama_komponen
                    });
                }
                ViewBag.Pengeluaran = lstKomp;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TambahDetail(Pengeluaran tmbh)
        {

            using (PengeluaranAllDAL data = new PengeluaranAllDAL())
            {
                try
                {
                    data.TambahDetail(tmbh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                        "success", "Data Pengeluaran " + tmbh.Nama_pengeluaran + " berhasil ditambah");
                    return RedirectToAction("TampilPengeluaran");
                }
                catch
                {
                    return View();
                }
            }
        }


        [Authorize]
        public ActionResult EditPengeluaran(int id)
        {
            using (PengeluaranAllDAL ubah = new PengeluaranAllDAL())
            {
                var data = ubah.TampilIDPengeluaran(id);
                return View(data);
            }
        }

        [HttpPost, ActionName("EditPengeluaran")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPengeluaran(Pengeluaran ubh)
        {
            using (PengeluaranAllDAL data = new PengeluaranAllDAL())
            {
                try
                {
                    data.UbahDetail(ubh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                       "success", "Data Komponen " + ubh.Nama_pengeluaran + " berhasil dirubah");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("TampilPengeluaran");
        }

        public ActionResult DeletePengeluaran(int? id)
        {
            if (id != null)
            {
                using (PengeluaranAllDAL data = new PengeluaranAllDAL())
                {
                    try
                    {
                        data.HapusDetail(id.Value);
                        TempData["Pesan"] = Pesan.GetPesan("Sukses !", "success", "Data Komponen  berhasil dihapus");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
            return RedirectToAction("TampilPengeluaran");
        }

        public ActionResult Cari(DateTime? dari, DateTime? ke)
        {
            using (PengeluaranAllDAL tgl = new PengeluaranAllDAL())
            {
                ViewBag.dari = dari;
                ViewBag.ke = ke;
                var results = tgl.CariTanggal(dari, ke).ToList();
                return View("TampilPengeluaran", results);
            }
        }

        public ActionResult TampilCicilan()
        {
            using (PengeluaranAllDAL tampil = new PengeluaranAllDAL())
            {
                var result = tampil.AmbilDataCicilan().ToList();
                if (TempData["Pesan"] != null)
                {
                    ViewBag.Pesan = TempData["Pesan"].ToString();
                }
                return View(result);
            }
        }

        public ActionResult TambahCicilan()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TambahCicilan(Cicilan tmbh)
        {

            using (PengeluaranAllDAL data = new PengeluaranAllDAL())
            {
                try
                {
                    data.TambahCicilan(tmbh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                        "success", "Data Pengeluaran " + tmbh.Nama_cicilan + " berhasil ditambah");
                    return RedirectToAction("TampilCicilan");
                }
                catch
                {
                    return View();
                }
            }
        }


        [Authorize]
        public ActionResult EditCicilan(int id)
        {
            using (PengeluaranAllDAL ubah = new PengeluaranAllDAL())
            {
                var data = ubah.TampilIDCicilan(id);
                return View(data);
            }
        }

        [HttpPost, ActionName("EditCicilan")]
        [ValidateAntiForgeryToken]
        public ActionResult EditCicilan(Cicilan ubh)
        {
            using (PengeluaranAllDAL data = new PengeluaranAllDAL())
            {
                try
                {
                    data.UbahCicilan(ubh);
                    TempData["Pesan"] = Pesan.GetPesan("Sukses !",
                       "success", "Data Komponen " + ubh.Nama_cicilan + " berhasil dirubah");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("TampilCicilan");
        }

        public ActionResult DeleteCicilan(int? id)
        {
            if (id != null)
            {
                using (PengeluaranAllDAL data = new PengeluaranAllDAL())
                {
                    try
                    {
                        data.HapusCicilan(id.Value);
                        TempData["Pesan"] = Pesan.GetPesan("Sukses !", "success", "Data Komponen  berhasil dihapus");
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
            return RedirectToAction("TampilCicilan");
        }
    }
}