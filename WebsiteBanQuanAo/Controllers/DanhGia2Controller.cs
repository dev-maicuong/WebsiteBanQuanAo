using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class DanhGia2Controller : Controller
    {
        // GET: DanhGia2
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public PartialViewResult DanhGia2(int ? masanpham)
        {
            List<DanhGia> dg = dt.DanhGias.Where(n=>n.MaSanPham == masanpham).ToList();
            Session["ma"] = masanpham;
            return PartialView(dg);
        }
        [HttpPost]
        public ActionResult DanhGia2([Bind(Include = "MaDanhGia,DanhGia1,MaNguoiDung,MaSanPham,NgayDanhGia")] DanhGia danhGia)
        {
            danhGia.MaSanPham = Int32.Parse(Session["MaSanPhamChiTiet"].ToString());
            danhGia.NgayDanhGia = DateTime.Now;
            dt.DanhGias.Add(danhGia);
            dt.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}