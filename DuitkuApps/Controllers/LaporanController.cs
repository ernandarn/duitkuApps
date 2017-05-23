using DuitkuApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Collections;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Enums;
using Newtonsoft.Json;
using System.Web.Services;
using System.Data.SqlClient;
using Microsoft.ReportingServices.DataProcessing;
using System.Data;
using DuitkuApps.DAL;

namespace DuitkuApps.Controllers
{
    public class LaporanController : Controller
    {
        private Model1Duitku db = new Model1Duitku();
       
        public ActionResult tampilLaporan()
        {
             var result = db.Penghasilan.Select(m => new { Nama_penghasilan = m.Nama_penghasilan, Jumlah = m.Jumlah }).ToList();
            ViewBag.Data = result;
            return View(result);
           
        }

        public ActionResult tampilLaporanperKomponen()
        {
            var detail = (from b in db.Komp_Pengeluaran
                          join kel in db.Pengeluaran on b.Id_komponen equals kel.Id_komponen
                          join real in db.Realisasi on b.Id_komponen equals real.id_komponen
                          where b.Id_komponen == kel.Id_komponen && b.Id_komponen == real.id_komponen
                          //group b by new { b.Nama_komponen } into g
                          select new
                          {
                              Nama_komponen = b.Nama_komponen,
                              Total_pengeluaran = kel.Jumlah,
                              Total_realisasi = real.Jumlah
                          });

            //var cicilan = (from b in db.Komp_Pengeluaran
            //               join cil in db.Cicilan on b.Id_komponen equals cil.Id_komponen
            //               join real in db.Realisasi on b.Id_komponen equals real.id_komponen
            //               where b.Id_komponen == cil.Id_komponen && b.Id_komponen == real.id_komponen
            //               group b by new { b.Nama_komponen } into g
            //               select new
            //               {
            //                   Nama_komponen = g.Key.Nama_komponen,
            //                   Total_cicilan = db.Cicilan.Sum(i => i.Jmlh_bayar),
            //                   Total_realisasi = db.Realisasi.Sum(i => i.Jumlah)
            //               });

            //var hasil = detail.Union(cicilan).ToList();
            //ViewBag.Hasil = hasil;
            ViewBag.Hasil = detail;
            return View(detail);

        }

        public ActionResult laporanKomponen()
        {
            var query = (from b in db.Komp_Pengeluaran
                          join cil in db.Cicilan on b.Id_komponen equals cil.Id_komponen
                          join det in db.Pengeluaran on b.Id_komponen equals det.Id_komponen
                          join real in db.Realisasi on b.Id_komponen equals real.id_komponen
                          //group b by new { cil.Id_komponen, det.Id_komponen, real.id_komponen } into g
                          select new
                          {
                              Nama_komponen = b.Nama_komponen,
                              Total_cicilan = cil.Jmlh_bayar,
                              Total_pengeluaran = det.Jumlah,
                              Total_realisasi = real.Jumlah
                          });
            ViewBag.Query = query;
            return View(query);
        }

    }
}
    