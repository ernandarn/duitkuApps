using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuitkuApps.Models;

namespace DuitkuApps.ViewModels
{
    public class PengeluaranGrid
    {
        public Komp_Pengeluaran komp { get; set; }
        public List<Pengeluaran> detailPengeluaran { get; set; }
        //public List<Cicilan> detailCicilan { get; set; }
    }
}