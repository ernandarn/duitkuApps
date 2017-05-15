using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuitkuApps.Models;
using DuitkuApps.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DuitkuApps.Controllers
{
    public class PenggunaController : Controller
    {
        // GET: Pengguna
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;
                if (Session["username"] == null)
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        Session["username"] = User.Identity.Name;
                    }
                    else
                    {
                        var tempUser = Guid.NewGuid().ToString();
                        Session["username"] = tempUser;
                    }
                    ViewBag.displayMenu = "No";
                }

                if (isPenggunaUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                return View();
            }
            else
            {
                ViewBag.Name = "Silahkan Masuk Terlebih Dahulu";
            }
            return View();



        }

        public ActionResult Create()
        {
            var lstSumber = new List<SelectListItem>();
            
            using (PenggunaDAL data = new PenggunaDAL())
            {
                foreach (var kec in data.AmbilDataSumber())
                {
                    lstSumber.Add(new SelectListItem
                    {
                        Value = kec.IdSumber.ToString(),
                        Text = kec.SumberPenghasilan
                    });
                }
                ViewBag.Master_SumberPenghasilan = lstSumber;
            }

            var lstStat = new List<SelectListItem>();
            using (PenggunaDAL data = new PenggunaDAL())
            {
                foreach (var kec in data.AmbilDataStatus())
                {
                    lstStat.Add(new SelectListItem
                    {
                        Value = kec.IdStatus.ToString(),
                        Text = kec.NamaStatus
                    });
                }
                ViewBag.Master_Status = lstStat;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pengguna tmbh)
        {
            using (PenggunaDAL data = new PenggunaDAL())
            {
                try
                {
                    data.Tambah(tmbh);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }

        public Boolean isPenggunaUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Pengguna")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}