using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuitkuApps.Models;
using DuitkuApps.ViewModels;

namespace DuitkuApps.Controllers
{
    public class PengeluaranGridController : Controller
    {
        // GET: PengeluaranGrid
        private Model1Duitku db = new Model1Duitku();
        public ActionResult Index()
        {
            List<PengeluaranGrid> grid = new List<PengeluaranGrid>();
            var komp = db.Komp_Pengeluaran.OrderByDescending(a => a.Id_komponen);
            foreach (var i in komp)
            {
                var detailsPengeluaran = db.Pengeluaran.Where(a => a.Id_komponen.Equals(i.Id_komponen)).ToList();
                //var detailsCicilan = db.Cicilan.Where(a => a.Id_komponen.Equals(i.Id_komponen)).ToList();
                grid.Add(new PengeluaranGrid { komp = i, detailPengeluaran = detailsPengeluaran});
            }
            return View(grid);
        }
    }
}