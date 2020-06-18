using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class DanhGiaController : Controller
    {
        // GET: DanhGia
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public PartialViewResult BinhLuan(int? masanpham)
        {
            List<BinhLuan> bl = dt.BinhLuans.Where(n => n.MaSanPham == masanpham).ToList();
            return PartialView(bl);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BinhLuan([Bind(Include = "MaBinhLuan,MaSanPham,MaNguoiDung,NoiDungBinhLuan,NgayDangBinhLuan")] BinhLuan binhLuan)
        {
            tbNguoiDung nd = (tbNguoiDung)Session["NguoiDung"];
            binhLuan.MaNguoiDung =nd.MaNguoiDung;
            binhLuan.MaSanPham = Int32.Parse(Session["MaSanPhamChiTiet"].ToString());
            binhLuan.NgayDangBinhLuan = DateTime.Now;
            dt.BinhLuans.Add(binhLuan);
            dt.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult TraLoiBinhLuan([Bind(Include = "MaTraLoiBinhLuan,MaBinhLuan,MaNguoiDung,NoiDungTraLoi,NgayTraLoi")] TraLoiBinhLuan traLoiBinhLuan)
        {
            tbNguoiDung nd = (tbNguoiDung)Session["NguoiDung"];
            traLoiBinhLuan.MaNguoiDung = nd.MaNguoiDung;
            traLoiBinhLuan.NgayTraLoi = DateTime.Now;
            dt.TraLoiBinhLuans.Add(traLoiBinhLuan);
            dt.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}