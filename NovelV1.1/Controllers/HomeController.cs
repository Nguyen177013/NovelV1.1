using NovelV1._1.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovelV1._1.Controllers
{
    public class HomeController : Controller
    {
        NovelDb context = new NovelDb();
        public ActionResult Index(string id = "")
        {
            if (id == "")
            {
                var listSach = context.Saches.ToList();
                return View(listSach);
            }
            else
            {
                return RedirectToAction("Type", "Home", new { id = id });
            }
        }
        public ActionResult topRead()
        {
            var listSach = context.Saches.ToList();
            return View(listSach);
        }
        public ActionResult timSach(string ten)
        {
            ViewBag.Find = ten;
            var find = (from ele in context.Saches select ele).OrderBy(p => p.Sach_ma);
            find = (IOrderedQueryable<Sach>)find.Where(p => p.Sach_ten.Contains(ten));
            if (find == null)
                return View();
            else
                return View(find);
        }
        public ActionResult Type(string id)
        {
            ViewBag.Type = id;

            var find = context.Saches.Where(p => p.TheLoai.TheLoai_ten == id).ToList();
            return View(find);
            /*            return RedirectToAction("Index","Admin");*/
        }
        public ActionResult Author(string id)
        {
            ViewBag.Author = id;
            var find = context.Saches.Where(p => p.Sach_TacGia == id).ToList();
            return View(find);
        }
        public ActionResult Detail(int? id, int? userId)
        {
            var detailBook = context.Saches.Where(p => p.Sach_ma == id).First();
            var read = context.NoiDungSaches.FirstOrDefault(p => p.Sach_ma == id);
            if (read != null)
            {
                ViewBag.read = "yes";
            }
            if (userId == null)
            {
                return View(detailBook);
            }
            else
            {
                var check = context.Sach_YeuThich.FirstOrDefault(p => p.Sach_ma == id && p.TaiKhoan_ma == userId);
                if (check != null)
                {
                    ViewBag.check = userId;
                }
                return View(detailBook);
            }
        }
        public ActionResult SachYeuThich(int sach, int? user)
        {
            if (user != null)
            {
                Sach_YeuThich s = new Sach_YeuThich();
                s.Sach_ma = sach;
                s.TaiKhoan_ma = user;
                context.Sach_YeuThich.Add(s);
                context.SaveChanges();
                return RedirectToAction("Detail", "Home", new { id = sach, userId = user });
            }
            else
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
        }
        public ActionResult BoYeuThich(int sach, int? user)
        {
            var check = context.Sach_YeuThich.Where(p => p.TaiKhoan_ma == user && p.Sach_ma == sach).FirstOrDefault();
            context.Sach_YeuThich.Remove(check);
            context.SaveChanges();
            return RedirectToAction("Detail", "Home", new { id = sach, userId = user });
        }
        public ActionResult listYeuThich(int? userID)
        {
            if (userID != null)
            {
                var list = context.Sach_YeuThich.Where(p => p.TaiKhoan_ma == userID).ToList();
                return View(list);
            }
            else
                return RedirectToAction("DangNhap", "TaiKhoan");
        }
        public ActionResult Read(int? id, int ep)
        {
            var reader = context.Saches.Where(p => p.Sach_ma == id).First();           
            var maxep = context.NoiDungSaches.Where(p => p.Sach_ma == id).Max(p => p.NoiDungSach_Tap);
            ViewBag.maxEp = maxep;
            var read = context.NoiDungSaches.Where(p => p.Sach_ma == id && p.NoiDungSach_Tap == ep).First();
            reader.Sach_LuotDoc += 1;
            context.SaveChanges();
            return View(read);
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/img/" + file.FileName));
            return "/Content/img/" + file.FileName;
        }
    }
}