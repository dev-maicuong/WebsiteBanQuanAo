using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult TimKiem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TimKiem(FormCollection f)
        {
            string tukhoa = f["TimKiem"].ToString();
            List<tbSanPham> sp = dt.tbSanPhams.Where(n => n.TenSanPham.Contains(tukhoa)).ToList();
            if(sp.Count == null)
            {
                ViewBag.timkiem = "không tìm thấy sản phẩm nào";
                return View(sp.OrderBy(n => n.TenSanPham).ToList());
            }
            ViewBag.timkiem2 = sp.Count + "Sản phẩm";
            return View(sp.OrderBy(n=>n.TenSanPham).ToList());
        }
    }
}