using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuitkuApps.Models;
using System.Web.Mvc;
using DuitkuApps.ViewModels;

namespace DuitkuApps.DAL
{
    public class PenggunaDAL : IDisposable
    {
        private Model1Duitku db = new Model1Duitku();
        public IQueryable<AspNetUsers> AmbilData()
        {
            //if (User.IsInRole("Pengguna"))
            //{
                var result = from b in db.AspNetUsers
                             orderby b.UserName
                             select b;
                return result;
            //} 
        }

        public IQueryable<Master_SumberPenghasilan> AmbilDataSumber()
        {
            var result = from b in db.Master_SumberPenghasilan
                         orderby b.SumberPenghasilan
                         select b;
            return result;
        }

        public IQueryable<Master_Status> AmbilDataStatus()
        {
            var result = from b in db.Master_Status
                         orderby b.NamaStatus
                         select b;
            return result;
        }

        public IQueryable<PenggunaVM> AmbilVM()
        {
            var query = (from b in db.Pengguna
                         join smbr in db.Master_SumberPenghasilan on b.IdSumber equals smbr.IdSumber
                         join stat in db.Master_Status on b.IdStatus equals stat.IdStatus
                         select new PenggunaVM
                         {
                             IdPengguna = b.IdPengguna,
                             UserName = b.UserName,
                             NamaPengguna = b.NamaPengguna,
                             Alamat = b.Alamat,
                             IdSumber = b.IdSumber,
                             SumberPenghasilan = smbr.SumberPenghasilan,
                             NoHp = b.NoHp,
                             NoKTP = b.NoKTP,
                             NoNPWP = b.NoNPWP,
                             IdStatus = b.IdStatus,
                             NamaStatus = stat.NamaStatus,
                             JmlTanggungan = b.JmlTanggungan,
                         });
            return query;
        }

        public void Tambah(Pengguna tambah)
        {
            db.Pengguna.Add(tambah);
            db.SaveChanges();
        }

      

        public void Dispose()
        {
            db.Dispose();
        }
    }
}