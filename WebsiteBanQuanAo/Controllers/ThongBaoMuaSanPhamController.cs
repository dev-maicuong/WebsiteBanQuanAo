using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;
namespace WebsiteBanQuanAo.Controllers
{
    public class ThongBaoMuaSanPhamController : Controller
    {
        // GET: ThongBaoMuaSanPham
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public PartialViewResult ThongBaoMuaSanPham()
        {
            var date = DateTime.Now.Day;
            return PartialView(dt.CTDatHangs.Where(n=>n.ThongTinThanhToan.NgayNhanSanPham.Value.Day == date).OrderByDescending(n=>n.ThongTinThanhToan.NgayNhanSanPham).Take(3).ToList());
        }
    }
}