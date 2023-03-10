using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTrip.Models.Siniflar;
namespace TravelTrip.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.Blogs.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var deger = c.Blogs.Find(id);
            return View("BlogGetir", deger);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blog = c.Blogs.Find(b.ID);
            blog.ID = b.ID;
            blog.Baslik = b.Baslik;
            blog.Tarih = b.Tarih;
            blog.BlogImage = b.BlogImage;
            blog.Aciklama = b.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var deger = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var deger = c.Yorumlars.Find(id);
            return View("YorumGetir", deger);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var deger = c.Yorumlars.Find(y.ID);
            deger.ID = y.ID;
            deger.KullaniciAdi = y.KullaniciAdi;
            deger.Mail = y.Mail;
            deger.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");

        }

    }
}