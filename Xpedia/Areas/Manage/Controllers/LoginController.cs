using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpedia.DAL;
using Xpedia.Areas.Manage.Models;
using System.Web.Helpers;

namespace Xpedia.Areas.Manage.Controllers
{
    public class LoginController : Controller
    {
        private readonly XpediaContext _context = new XpediaContext();

        // GET: Manage/Login
        public ActionResult Index()
        {
            if (Session["AdminLogin"] != null)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        public ActionResult Login(Admin admin)
        {
            if (string.IsNullOrEmpty(admin.Email) || string.IsNullOrEmpty(admin.Password))
            {
                Session["LoginError"] = "E-poçt və şifrə boş olmamalıdır !";
                return RedirectToAction("index");
            }

            Admin adm = _context.Admins.FirstOrDefault(a => a.Email == admin.Email);
            if (adm != null)
            {
                if (Crypto.VerifyHashedPassword(adm.Password, admin.Password))
                {
                    Session["AdminLogin"] = true;
                    Session["Admin"] = adm;
                    Session["Adminname"] = adm.Fullname;
                    return RedirectToAction("index", "home");
                }
            }

            Session["LoginError"] = "E-poçt və ya şifrə düzgün deyil";
            return RedirectToAction("index");
        }
    }
}