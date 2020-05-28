using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class DemSanPhamNuController : Controller
    {
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        // GET: DemSanPhamNu
        public PartialViewResult DemSanPhamNu()
        {
            List<tbSanPham> sanphamnu = dt.tbSanPhams.Where(n=>n.GioiTinh == 1).ToList();
            ViewBag.tongsanphamnu = sanphamnu.Count;
            return PartialView();
        }
    }
}