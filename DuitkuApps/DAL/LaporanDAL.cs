using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuitkuApps.Models;
using DuitkuApps.ViewModels;

namespace DuitkuApps.DAL
{
    public class LaporanDAL : IDisposable
    {
        private Model1Duitku db = new Model1Duitku();

        public void Dispose()
        {
            db.Dispose();
        }

        //public IQueryable<LaporanVM> Tampil()
        //{
        //    var detail = (from b in db.Komp_Pengeluaran
        //                  join kel in db.Pengeluaran on b.Id_komponen equals kel.Id_komponen
        //                  join real in db.Realisasi on b.Id_komponen equals real.id_komponen
        //                  where b.Id_komponen == kel.Id_komponen && b.Id_komponen == real.id_komponen
        //                  group b by new { b.Nama_komponen } into g
        //                  select new
        //                  {
        //                      Nama_komponen = g.Key.Nama_komponen,
        //                      Total_pengeluaran = db.Pengeluaran.Sum(i => i.Jumlah),
        //                      Total_realisasi = db.Realisasi.Sum(i => i.Jumlah)
        //                  });

        //    var cicilan = (from b in db.Komp_Pengeluaran
        //                   join cil in db.Cicilan on b.Id_komponen equals cil.Id_komponen
        //                   join real in db.Realisasi on b.Id_komponen equals real.id_komponen
        //                   where b.Id_komponen == cil.Id_komponen && b.Id_komponen == real.id_komponen
        //                   group b by new { b.Nama_komponen } into g
        //                   select new
        //                   {
        //                       Nama_komponen = g.Key.Nama_komponen,
        //                       Total_cicilan = db.Cicilan.Sum(i => i.Jmlh_bayar),
        //                       Total_realisasi = db.Realisasi.Sum(i => i.Jumlah)
        //                   });

        //    var hasil = detail.Union(cicilan).ToList();
        //    return hasil;
        //}
    }
}