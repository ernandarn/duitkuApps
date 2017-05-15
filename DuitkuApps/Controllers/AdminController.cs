using DuitkuApps.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuitkuApps.DAL;

namespace DuitkuApps.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
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

                if (isAdminUser())
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

        public ActionResult tampilPengguna()
        {
            using (PenggunaDAL tampil = new PenggunaDAL())
            {   
                var result = tampil.AmbilData().ToList();
                return View(result);         
            }
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
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