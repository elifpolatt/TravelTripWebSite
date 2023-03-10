using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTrip.Models.Siniflar;

namespace TravelTrip.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var degerler = c.Admins.FirstOrDefault(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);
            {
                if (degerler != null)
                {
                    FormsAuthentication.SetAuthCookie(degerler.Kullanici, false);
                    Session["Kullanici"] = degerler.Kullanici.ToString();
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View();
                }

            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}