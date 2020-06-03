using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;
using PagedList;
using PagedList.Mvc;


namespace WebsiteBanQuanAo.Controllers
{
    public class SanPhamDuocMuaNhieuNhatController : Controller
    {
        // GET: SanPhamDuocMuaNhieuNhat
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();

        public ActionResult AoNuDuocMuaNhieuNhat( int ? page)
        {
            int size = 8;
            int number = (page ?? 1);
            return View(dt.tbSanPhams.Where( n=> n.GioiTinh == 1 && n.LoaiSanPham == false).OrderByDescending(n=>n.LuongMua).Take(8).ToPagedList(number,size));
        }
        public ActionResult QuanNuDuocMuaNhieuNhat()
        {
            return View();
        }
        public ActionResult AoNamDuocMuaNhieuNhat()
        {
            return View();
        }
        public ActionResult QuanNamDuocMuaNhieuNhat()
        {
            return View();
        }
    }
}