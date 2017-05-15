using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuitkuApps.Models;
using System.Web.Mvc;
using DuitkuApps.ViewModels;

namespace DuitkuApps.DAL
{
    public class PenghasilanDAL : IDisposable
    {
        private Model1Duitku db = new Model1Duitku();

        public IQueryable<Penghasilan> Tampil()
        {
            var result = from b in db.Penghasilan
                         orderby b.Tanggal
                         select b;
            return result;


            //var tampil = from b in db.Penghasilan
            //                   group b by b.Tanggal.Year into g
            //                   select new { Key = g.Key, Values = g };
            //return tampil;
        }

        public Penghasilan TampilByID(int id)
        {
            var result = (from b in db.Penghasilan
                          where b.Id_penghasilan == id
                          orderby b.Nama_penghasilan
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

        public void Tambah(Penghasilan obj)
        {
            try
            {
                db.Penghasilan.Add(obj);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Ubah(Penghasilan ubh)
        {
            var result = TampilByID(ubh.Id_penghasilan);
            if (result != null)
            {
                //if(result.Tanggal == DateTime.Now)
                //{
                result.Id_penghasilan = ubh.Id_penghasilan;
                result.Username = ubh.Username;
                result.Nama_penghasilan = ubh.Nama_penghasilan;
                result.Tanggal = ubh.Tanggal;
                result.Jumlah = ubh.Jumlah;
                result.Keterangan = ubh.Keterangan;
                db.SaveChanges();
            }
            //}
            //else
            //{
            //    throw new Exception("Data dapat diubah pada tanggal yang sama");
            //}
            
            
            else
            {
                throw new Exception("Data Gagal Diubah");
            }
        }

        public void HapusData(int id)
        {
            var result = TampilByID(id);
            if (result != null)
            {
                db.Penghasilan.Remove(result);
                try
                {
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

        public IEnumerable<Penghasilan> Filter(DateTime? dari, DateTime? ke)
        {
            var cari = db.Penghasilan.Where(c => c.Tanggal >= dari && c.Tanggal <= ke).ToList();
            return cari;

        }



        public IQueryable<Penghasilan> Cari(string txtSearch)
        {
            var result = from a in db.Penghasilan
                         where a.Nama_penghasilan.ToLower().Contains(txtSearch.ToLower())
                         select a;
            return result;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}