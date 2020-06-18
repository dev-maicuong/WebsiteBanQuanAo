using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;
namespace WebsiteBanQuanAo.Controllers
{
    public class HienThiController : Controller
    {
        // GET: HienThi
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public PartialViewResult Menu()
        {
            return PartialView(dt.tbSanPhams.Where(n=>n.LuongMua>800).ToList());
        }
        public PartialViewResult SanPhamMoiNhat()
        {
            return PartialView(dt.tbSanPhams.ToList());
        }
        public PartialViewResult SanPhamLienQuan(Boolean loaisanpham)
        {
            return PartialView(dt.tbSanPhams.Where(n=>n.LoaiSanPham == loaisanpham).OrderByDescending(n=>n.NgayTao).Take(5).ToList());
        }
        public PartialViewResult GiamGiaManh()
        {
            return PartialView(dt.tbSanPhams.Where(n=>n.Sale == true).Take(4).ToList());
        }
        public PartialViewResult SanPhamMoi()
        {
            return PartialView(dt.tbSanPhams.Where(n=>n.SanPhamMoiorCu == "Mới").OrderByDescending(n=>n.NgayTao).Take(7).ToList());
        }
        public ActionResult AoNuDuocMuaNhieu()
        {
            return View(dt.tbSanPhams.Where(n=>n.GioiTinh==1 && n.LoaiSanPham ==false).OrderByDescending(n => n.LuongMua).Take(10).ToList());
        }
        public ActionResult QuanNuDuocMuaNhieuNhat()
        {
            return View(dt.tbSanPhams.Where(n => n.GioiTinh == 1 && n.LoaiSanPham == true).OrderByDescending(n => n.LuongMua).Take(10).ToList());
        }
        public ActionResult AoNamDuocMuaNhieuNhat()
        {
            return View(dt.tbSanPhams.Where(n => n.GioiTinh == 0 && n.LoaiSanPham == false).OrderByDescending(n => n.LuongMua).Take(10).ToList());
        }
        public ActionResult QuanNamDuocMuaNhieuNhat()
        {
            return View(dt.tbSanPhams.Where(n => n.GioiTinh == 0 && n.LoaiSanPham == true).OrderByDescending(n => n.LuongMua).Take(10).ToList());
        }
    }
}