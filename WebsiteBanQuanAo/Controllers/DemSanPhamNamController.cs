using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class DemSanPhamNamController : Controller
    {
        // GET: DemSanPhamNam
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public PartialViewResult DemSanPhamNam()
        {
            List<tbSanPham> sanphamnam = dt.tbSanPhams.Where(n => n.GioiTinh == 0).ToList(); // lấy sản phẩm điều kiện là giới tính
            ViewBag.tongsanphamnam = sanphamnam.Count; // đếm các sản phẩm đã lấy bằng hàng Count
            return PartialView();
        }
    }
}