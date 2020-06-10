using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class AdminDemSanPhamController : Controller
    {
        // GET: AdminDemSanPham
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public PartialViewResult AdminDemSanPham()
        {
            List<tbSanPham> sp = dt.tbSanPhams.ToList();
            ViewBag.dem = sp.Count + " sản phẩm";
            return PartialView();
        }
    }
}