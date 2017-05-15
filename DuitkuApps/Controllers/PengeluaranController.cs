using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuitkuApps.Models;
using DuitkuApps.DAL;
using DuitkuApps.ViewModels;
using System.Data.Entity.Validation;

namespace DuitkuApps.Controllers
{
    public class PengeluaranController : Controller
    {
        private Model1Duitku db = new Model1Duitku(); 

        // GET: Pengeluaran
        //public ActionResult Index()
        //{
        //    using (PengeluaranDAL tampil = new PengeluaranDAL())
        //    {
        //        var result = tampil.Tampil().ToList();
        //        return View(result);
        //    }
        //}


        //[HttpPost]
        //public ActionResult Create(PengeluaranVM viewModel)
        //{
        //    var komp = new Komp_Pengeluaran()
        //    {
        //        Username = Session["Username"].ToString(),
        //        Nama_komponen = viewModel.Nama_komponen,
        //        Batas_max = viewModel.Batas_max
        //    };
        //    using (PengeluaranDAL data = new PengeluaranDAL())
        //    {
        //        data.TambahKomp(komp);
        //        foreach (var ord in data.Tampil())
        //        {
        //            var detail = new Pengeluaran
        //            {
        //                Id_komponen = komp.Id_komponen,
        //                Id_pengeluaran = ord.Id_pengeluaran,
        //                Nama_pengeluaran = ord.Nama_pengeluaran,
        //                Jumlah = ord.Jumlah,
        //                Keterangan = ord.Keterangan,
        //            };
        //            data.TambahDetail(detail);
        //        }
        //    }
        //    return RedirectToAction("Index", new { id = komp.Id_komponen });
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Create(PengeluaranVM viewModel)
        {
            try
            {
                var komp = new Komp_Pengeluaran()
            {
                Id_komponen = viewModel.Id_komponen,
                //Username = viewModel.Username,
                //Id_cicilan = viewModel.Id_cicilan,
                Nama_komponen = viewModel.Nama_komponen,
                //Batas_max = viewModel.Batas_max
            };

            var detail = new Pengeluaran()
            {
                Id_pengeluaran = viewModel.Id_pengeluaran,
                Id_komponen = viewModel.Id_komponen,
                //Id_realisasi = viewModel.Id_realisasi,
                Nama_pengeluaran = viewModel.Nama_pengeluaran,
                Jumlah = viewModel.Jumlah,
                Keterangan = viewModel.Keterangan,
            };
            db.Komp_Pengeluaran.Add(komp);
            db.Pengeluaran.Add(detail);
            db.SaveChanges();
            return View();


            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            //return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult Create(PengeluaranView viewModel)
        //{
        //    using (PengeluaranDAL data = new PengeluaranDAL())
        //    {
        //        //var komp = data.AmbilKompID(viewModel.SelectedValue);
        //        var komps = data.AmbilKomponen();

        //       // viewModel.Komp_Pengeluaran = komp ;

        //        var klr = new Pengeluaran
        //        {
        //            Id_pengeluaran = viewModel.Id_pengeluaran,
        //            Id_realisasi = viewModel.Id_realisasi,
        //            Nama_pengeluaran = viewModel.Nama_pengeluaran,
        //            Jumlah = viewModel.Jumlah,
        //            Keterangan = viewModel.Keterangan,
        //        };
        //        if (ModelState.IsValid) //check for any validation errors
        //        {
        //            //code to save valid data into database

        //            return RedirectToAction("Create");
        //        }
        //        else
        //        {
        //            //when validation failed return viewmodel back to UI (View)
        //            return View(viewModel);
        //        }
        //    }




    }


    }
