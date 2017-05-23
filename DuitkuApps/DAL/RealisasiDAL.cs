using DuitkuApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuitkuApps.DAL
{
    public class RealisasiDAL : IDisposable
    {
        private Model1Duitku db = new Model1Duitku();

        public IQueryable<Realisasi> AmbilDataRealisasi()
        {
            var result = from b in db.Realisasi
                         orderby b.Tanggal
                         select b;
            return result;
        }

        public IQueryable<Komp_Pengeluaran> AmbilDataKomponen()
        {
            var result = from b in db.Komp_Pengeluaran
                         orderby b.Nama_komponen
                         select b;
            return result;
        }


        public Realisasi TampilIDReal(int id)
        {
            var result = (from b in db.Realisasi
                          where b.Id_realisasi == id
                          orderby b.Tanggal
                          select b).SingleOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Data Tidak Ditemukan !");
            }
        }

        public void TambahRealisasi(Realisasi tambah)
        {
            db.Realisasi.Add(tambah);
            db.SaveChanges();
        }

        public void UbahRealisasi(Realisasi ubh)
        {
            var result = TampilIDReal(ubh.Id_realisasi);
            if (result != null)
            {
                result.Id_realisasi = ubh.Id_realisasi;
                result.Jumlah = ubh.Jumlah;
                result.Tanggal = ubh.Tanggal;
                result.Nama_realisasi = ubh.Nama_realisasi;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data Gagal Diubah");
            }
        }

        public void HapusRealisasi(int id)
        {
            var result = TampilIDReal(id);
            if (result != null)
            {
                try
                {
                    db.Realisasi.Remove(result);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                throw new Exception("Data tidak dapat dihapus !");
            }
        }

        public IEnumerable<Realisasi> CariTanggal(DateTime? dari, DateTime? ke)
        {
            var cari = db.Realisasi.Where(c => c.Tanggal >= dari && c.Tanggal < ke).ToList();
            return cari;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}