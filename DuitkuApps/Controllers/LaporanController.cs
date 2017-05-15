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

        //public ActionResult tampilLaporanKomponen()
        //{
        //    var result = db.Pengeluaran.Select(m => new {  = m.Nama_komponen, Jumlah = m.Jumlah }).ToList();
        //    ViewBag.Data = result;
        //    return View(result);

        //}

    }
}
    