using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class DangNhapController : Controller
    {
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            String taikhoan = f["Email"].ToString();
            String matkhau = f["Password"].ToString();
            tbNguoiDung nd = dt.tbNguoiDungs.SingleOrDefault(n => n.TaiKhoanNguoiDung == taikhoan && n.MatKhauNguoiDung == matkhau);
            if( nd != null)
            {
                Session["NguoiDung"] = nd;
                return Redirect("/Home/Index");
            }
            else
            {
                ViewBag.ThongBao = "sai tai khoan hoac mat khau ";
            }
            return View();
        }
    }
}