using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class ThanhToanController : Controller
    {
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        // GET: ThanhToan
        public ActionResult ThongTinThanhToan()
        {
            List<ClassGioHangTamThoi> giohangtamthoi = Session["GioHangTamThoi"] as List<ClassGioHangTamThoi>;
            tbNguoiDung nd = dt.tbNguoiDungs.Find(Int32.Parse(Session["MaNguoiDung"].ToString()));
            ThongTinThanhToan tttt = new ThongTinThanhToan();
            tttt.MaNguoiDung = nd.MaNguoiDung;
            tttt.TenNguoiDung = nd.TenNguoiDung;
            tttt.DiaChiNguoiDung = nd.DiaChiNguoiDung;
            tttt.SDTNguoiDung = nd.SDTNguoiDung;
            tttt.GioiTinhNguoiDung = nd.GioiTinhNguoiDung;
            tttt.TaiKhoanNguoiDung = nd.TaiKhoanNguoiDung;
            var i = giohangtamthoi;
            tttt.TongTien = i.Sum(t => t.DonGia);
            tttt.SoLuong = i.Sum(t => t.SoLuong);
            return View(tttt);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThongTinThanhToan([Bind(Include = "MaTTTT,MaNguoiDung,TenNguoiDung,DiaChiNguoiDung,SDTNguoiDung,GioiTinhNguoiDung,SoLuong,TongTien,TaiKhoanNguoiDung,NgayNhanSanPham")] ThongTinThanhToan thongTinThanhToan)
        {
            if (ModelState.IsValid)
            {
                thongTinThanhToan.NgayNhanSanPham = DateTime.Now;
                dt.ThongTinThanhToans.Add(thongTinThanhToan);
                dt.SaveChanges(); 
            }
            ViewBag.MaNguoiDung = new SelectList(dt.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", thongTinThanhToan.MaNguoiDung);
            return RedirectToAction("CTDatHang", new { MaTTTT = thongTinThanhToan.MaTTTT });
        }
        public RedirectToRouteResult CTDatHang(int MaTTTT)
        {
            List<ClassGioHangTamThoi> giohangtamthoi = Session["GioHangTamThoi"] as List<ClassGioHangTamThoi>;
            foreach (var item in giohangtamthoi)
            {
                CTDatHang dh = new CTDatHang();
                dh.MaTTTT = MaTTTT;
                dh.MaSanPham = item.MaSanPham;
                dt.CTDatHangs.Add(dh);
            }
            dt.SaveChanges();
            return RedirectToAction("XacNhan");
        }
        public ActionResult XacNhan()
        {
            Session["GioHangTamThoi"] = null;
            Session["Dem"] = null;
            return View();
        }
    }
}