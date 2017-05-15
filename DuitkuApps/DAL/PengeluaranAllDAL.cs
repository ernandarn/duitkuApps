using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuitkuApps.Models;
using DuitkuApps.ViewModels;

namespace DuitkuApps.DAL
{
    public class PengeluaranAllDAL : IDisposable
    {
        private Model1Duitku db = new Model1Duitku();

        //komponen pengeluaran
        public IQueryable<Komp_Pengeluaran> AmbilDataKomp()
        {
            var result = from b in db.Komp_Pengeluaran
                         orderby b.Nama_komponen
                         select b;
            return result;
        }

        public Komp_Pengeluaran TampilIDKomp(int id)
        {
            var result = (from b in db.Komp_Pengeluaran
                          where b.Id_komponen == id
                          orderby b.Nama_komponen
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

        public void TambahKomp(Komp_Pengeluaran tambah)
        {
            db.Komp_Pengeluaran.Add(tambah);
            db.SaveChanges();
        }

        public void UbahKomp(Komp_Pengeluaran ubh)
        {
            var result = TampilIDKomp(ubh.Id_komponen);
            if (result != null)
            {
                result.Id_komponen = ubh.Id_komponen;
                result.Username = ubh.Username;
                result.Nama_komponen = ubh.Nama_komponen;
                result.Batas_max = ubh.Batas_max;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data Gagal Diubah");
            }
        }

        public void HapusKomp(int id)
        {
            var result = TampilIDKomp(id);
            if (result != null)
            {
                try
                {
                    db.Komp_Pengeluaran.Remove(result);
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


        //Pengeluaran
        public IQueryable<Pengeluaran> AmbilDataPengeluaran()
        {
            var result = from b in db.Pengeluaran
                         orderby b.Tanggal
                         select b;
            return result;
        }


        public Pengeluaran TampilIDPengeluaran(int id)
        {
            var result = (from b in db.Pengeluaran
                          where b.Id_pengeluaran == id
                          orderby b.Nama_pengeluaran
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


        public void TambahDetail(Pengeluaran tambah)
        {
            db.Pengeluaran.Add(tambah);
            db.SaveChanges();
        }

        public void UbahDetail(Pengeluaran ubh)
        {
            var result = TampilIDPengeluaran(ubh.Id_pengeluaran);
            if (result != null)
            {
                result.Id_pengeluaran = ubh.Id_pengeluaran;
                result.Tanggal = ubh.Tanggal;
                result.Jumlah = ubh.Jumlah;
                result.Keterangan = ubh.Keterangan;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data Gagal Diubah");
            }
        }

        public void HapusDetail(int id)
        {
            var result = TampilIDPengeluaran(id);
            if (result != null)
            {
                try
                {
                    db.Pengeluaran.Remove(result);
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

        //Cicilan
        public IQueryable<Cicilan> AmbilDataCicilan()
        {
            var result = from b in db.Cicilan
                         orderby b.Nama_cicilan
                         select b;
            return result;
        } 

        public Cicilan TampilIDCicilan(int id)
        {
            var result = (from b in db.Cicilan
                          where b.Id_cicilan == id
                          orderby b.Nama_cicilan
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

        public void TambahCicilan(Cicilan tambah)
        {
            db.Cicilan.Add(tambah);
            db.SaveChanges();
        }

        public void UbahCicilan(Cicilan ubh)
        {
            var result = TampilIDCicilan(ubh.Id_cicilan);
            if (result != null)
            {
                result.Id_cicilan = ubh.Id_cicilan;
                result.Nama_cicilan = ubh.Nama_cicilan;
                result.Tgl_mulai = ubh.Tgl_mulai;
                result.Tgl_bayar = ubh.Tgl_bayar;
                result.Jmlh_bayar = ubh.Jmlh_bayar;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Data Gagal Diubah");
            }
        }

        public void HapusCicilan(int id)
        {
            var result = TampilIDCicilan(id);
            if (result != null)
            {
                try
                {
                    db.Cicilan.Remove(result);
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

        //public IQueryable<DetailVM> AmbilDetailVM(int id)
        //{
        //    var result = from a in db.Pengeluaran.Include("Komp_Pengeluaran")
        //                 where a.Id_komponen == id
        //                 select new DetailVM
        //                 {
        //                     Id_pengeluaran = a.Id_pengeluaran,
        //                     Id_komponen = a.Komp_Pengeluaran.Id_komponen,
        //                     Nama_komponen = a.Komp_Pengeluaran.Nama_komponen,
        //                     Tanggal = a.Tanggal,
        //                     Nama_pengeluaran = a.Nama_pengeluaran,
        //                     Jumlah = a.Jumlah,
        //                     Keterangan = a.Keterangan,
        //                 };
        //    return result;
        //}


        //public IQueryable<PengeluaranAllView> AmbilVM()
        //{
        //    var query = (from b in db.Komp_Pengeluaran
        //                 join klr in db.Pengeluaran on b.Id_komponen equals klr.Id_komponen
        //                 join real in db.Realisasi on klr.Id_realisasi equals real.Id_realisasi
        //                 select new PengeluaranAllView
        //                 {
        //                     Id_komponen = b.Id_komponen,
        //                     Username = b.Username,
        //                     Nama_komponen = b.Nama_komponen,
        //                     Batas_max = b.Batas_max,
        //                     Id_pengeluaran = klr.Id_pengeluaran,
        //                     Tanggal = klr.Tanggal,
        //                     Keterangan = klr.Keterangan,
        //                     Id_realisasi = real.Id_realisasi,
        //                     TanggalRealisasi = real.Tanggal,
        //                     Nama_realisasi = real.Nama_realisasi,
        //                 });
        //    return query;
        //}

        //public IQueryable<Pengeluaran> AmbilSemua(int kode)
        //{
        //    var results = from s in db.Pengeluaran.Include("Komp_Pengeluaran")
        //                  where s.Id_pengeluaran == kode
        //                  orderby s.Tanggal ascending
        //                  select s;
        //    return results;
        //}

        //public Pengeluaran AmbilIDKomponen(int kode)
        //{
        //    var result = (from s in db.Pengeluaran
        //                  where s.Id_komponen == kode
        //                  select s).FirstOrDefault();

        //    return result;
        //}

        //public Pengeluaran CekIDKomponen(int kode, int id)
        //{
        //    var result = (from s in db.Pengeluaran
        //                  where s.Id_komponen == kode && s.Id_pengeluaran == id
        //                  select s).FirstOrDefault();

        //    return result;
        //}

        //public void UbahPengeluaran(int id, int kode)
        //{
        //    var results = from s in db.Pengeluaran
        //                  where s.Id_komponen == id
        //                  select s;

        //    foreach (var sc in results)
        //    {
        //        sc.Id_komponen = kode;
        //    }
        //    db.SaveChanges();
        //}

        //public void TambahPengeluaran(Pengeluaran sc)
        //{
        //    var result = CekIDKomponen(sc.Id_komponen, sc.Id_pengeluaran);
        //    var id = TampilIDKomp(sc.Id_komponen);
        //    if (result != null)
        //    {
        //        try
        //        {
        //            db.Pengeluaran.Add(sc);
        //            db.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message, ex.InnerException);
        //            //throw new Exception(ex.Message, ex.InnerException);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Data Gagal Ditambah !");
        //    }
        //}

        

        public void Dispose()
        {
            db.Dispose();
        }
    }
}