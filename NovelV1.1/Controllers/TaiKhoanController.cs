using NovelV1._1.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using System.Configuration;
using System.Data.Entity.Validation;
using Common;

namespace NovelV1._1.Controllers
{
    public class TaiKhoanController : Controller
    {
        NovelDb context = new NovelDb();

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(TaiKhoan tk)
        {
            if (context.TaiKhoans.Any(p => p.TaiKhoan_tenDN == tk.TaiKhoan_tenDN))
            {
                ViewBag.Notification = "Tài Khoản Đã Tồn Tại";
                return View();
            }
            if(context.TaiKhoans.Any(p => p.TaiKhoan_email == tk.TaiKhoan_email))
            {
                ViewBag.Notification = "Email Đã Tồn Tại";
                return View();
            }
            else
            {
                tk.TaiKhoan_tien = 0;
                context.TaiKhoans.Add(tk);
                context.SaveChanges();
                Session["TaiKhoan_maSS"] = tk.TaiKhoan_ma;
                Session["TaiKhoan_taiKhoanSS"] = tk.TaiKhoan_tenDN;
                Session["TaiKhoan_tenDNSS"] = tk.TaiKhoan_tenDN;
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(TaiKhoan tk)
        {
            var checkLogin = context.TaiKhoans.Where(p => p.TaiKhoan_tenDN.Equals(tk.TaiKhoan_tenDN) &&
            p.TaiKhoan_matKhau.Equals(tk.TaiKhoan_matKhau)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["TaiKhoan_maSS"] = checkLogin.TaiKhoan_ma;
                Session["TaiKhoan_tenDNSS"] = checkLogin.TaiKhoan_hoTen;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Tài Khoản Hoặc Mật Khẩu Không Hợp Lệ";
            }
            return View();
        }
        public ActionResult DangNhapFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
        public int InsertForFacebook(TaiKhoan user)
        {
            var check = context.TaiKhoans.SingleOrDefault(p => p.TaiKhoan_tenDN == user.TaiKhoan_tenDN);
            if (check == null)
            {
                context.TaiKhoans.Add(user);
                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
                return user.TaiKhoan_ma;
            }
            else
                return check.TaiKhoan_ma;
        }
        public ActionResult FacebookCallback(string code)
        {

            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var user = new TaiKhoan();
                user.TaiKhoan_hoTen = firstname + " " + middlename + " " + lastname;
                user.TaiKhoan_email = email;
                user.TaiKhoan_tenDN = firstname + " " + middlename + " " + lastname;
                user.TaiKhoan_matKhau = email;
                user.TaiKhoan_MatKhauXacNhan = email;
                user.TaiKhoan_tien = 0;
                int check = InsertForFacebook(user);
                if (check > 0)
                {
                    Session["TaiKhoan_maSS"] = check;
                    Session["TaiKhoan_tenDNSS"] = firstname + " " + middlename + " " + lastname;
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(TaiKhoan tk)
        {
            var check = context.TaiKhoans.Where(p => p.TaiKhoan_email == tk.TaiKhoan_email).FirstOrDefault();
            if (check != null)
            {
                string content = System.IO.File.ReadAllText(Server.MapPath("~/assets/client/template/neworder.html"));
                content = content.Replace("{{CustomerName}}", check.TaiKhoan_hoTen);
                content = content.Replace("{{CustomerAccount}}", check.TaiKhoan_tenDN);
                content = content.Replace("{{Email}}", check.TaiKhoan_email);
                content = content.Replace("{{Total}}", check.TaiKhoan_tien.ToString());
                content = content.Replace("{{Url}}", "https://localhost:44361/TaiKhoan/changePassword/"+check.TaiKhoan_ma);

                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                new MailHelper().SendMail(check.TaiKhoan_email, "Đổi Mật Khẩu", content);
                ViewBag.Notification = "Vui Lòng Kiểm Tra Email";
                return View();
            }
            else
            {
                ViewBag.Notification = "Không Tồn Tại Email Trên";
                return View();
            }
        }
        public ActionResult changePassword(int id)
        {
            var check = context.TaiKhoans.Where(p => p.TaiKhoan_ma == id).FirstOrDefault();
            return View(check);
        }
        [HttpPost]
        public ActionResult changePassword(int id,TaiKhoan tk)
        {
            var check = context.TaiKhoans.Where(p=>p.TaiKhoan_ma == id).FirstOrDefault();
            if(check != null)
            {
                check.TaiKhoan_hoTen = check.TaiKhoan_hoTen;
                check.TaiKhoan_tenDN = check.TaiKhoan_tenDN;
                check.TaiKhoan_email = check.TaiKhoan_email;
                check.TaiKhoan_matKhau = tk.TaiKhoan_matKhau;
                check.TaiKhoan_MatKhauXacNhan = tk.TaiKhoan_matKhau;
                context.SaveChanges();
                 return RedirectToAction("Index", "Home");
            }
            else
                return View();
        }
    }
}