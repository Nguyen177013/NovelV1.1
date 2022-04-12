using NovelV1._1.Models.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovelV1._1.Controllers
{
    public class TheLoaiController : Controller
    {
        NovelDb context = new NovelDb();
        public ActionResult TypePartial()
        {
            var listType = context.TheLoais.ToList();
            Hashtable tenloai = new Hashtable();
            foreach (var ele in listType)
            {
                tenloai.Add(ele.TheLoai_ma, ele.TheLoai_ten);
            }
            ViewBag.tenloai = tenloai;
            return PartialView("TypePartial");
        }
    }
}