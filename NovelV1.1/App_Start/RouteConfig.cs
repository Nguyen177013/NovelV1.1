using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NovelV1._1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //------------------Thực Thi URL Tài Khoản---------------------------------//
            //--------------------Url Reset----------------//
            routes.MapRoute(
                name: "ResetPassword",
                url: "XacNhanEmail/{id}",
                defaults: new { controller = "TaiKhoan", action = "ResetPassword", id = UrlParameter.Optional }
            );
            //--------------------Url DangNhap----------------//
            routes.MapRoute(
                name: "DangNhap",
                url: "DangNhap/{id}",
                defaults: new { controller = "TaiKhoan", action = "DangNhap", id = UrlParameter.Optional }
            );

            //--------------------Url DangKy----------------//
            routes.MapRoute(
                name: "DangKy",
                url: "DangKy/{id}",
                defaults: new { controller = "TaiKhoan", action = "DangKy", id = UrlParameter.Optional }
            );

            //----------------------Kết Thúc URL Tài Khoản ----------------------------//

            //-------------------Thực Thi URL Đọc Sách------------------------------//

            //--------------URL TopSach--------------//
            routes.MapRoute(
                name: "Type",
                url: "TheLoai/{id}",
                defaults: new { controller = "Home", action = "Type", id = UrlParameter.Optional }
            );
            //--------------URL TopSach--------------//
            routes.MapRoute(
                name: "topRead",
                url: "TopDoc/{id}",
                defaults: new { controller = "Home", action = "topRead", id = UrlParameter.Optional }
            );
            //--------------URL DetailSach--------------//
            routes.MapRoute(
                name: "Detail",
                url: "Detail/{MetaTitle}-{id}",
                defaults: new { controller = "Home", action = "Detail", id = UrlParameter.Optional }
            );
            //--------------URL TimSach--------------//
            routes.MapRoute(
                name: "timSach",
                url: "timkiem/{id}",
                defaults: new { controller = "Home", action = "timSach", id = UrlParameter.Optional }
            );
            //--------------URL ListYeuThich--------------//
            routes.MapRoute(
                name: "listYeuThich",
                url: "YeuThich/{id}",
                defaults: new { controller = "Home", action = "listYeuThich", id = UrlParameter.Optional }
            );
            //--------------URL Read--------------//
            routes.MapRoute(
                name: "Read",
                url: "Read/{id}",
                defaults: new { controller = "Home", action = "Read", id = UrlParameter.Optional }
            );

            //---------------------Kết THúc URL Đọc Sách ---------------------//
            //--------------Url Index----------------//
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
