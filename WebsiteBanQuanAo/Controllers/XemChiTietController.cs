using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class XemChiTietController : Controller
    {
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        // GET: XemChiTiet
        public ActionResult XemChiTietSanPham( int masanpham=0)
        {
            return View(dt.tbSanPhams.SingleOrDefault(n=>n.MaSanPham == masanpham));
        }
    }
}