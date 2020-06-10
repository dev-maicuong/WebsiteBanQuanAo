using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class DoiMatKhauKhachHangController : Controller
    {
        // GET: DoiMatKhauKhachHang    
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult DoiMatKhauKhachHang(FormCollection f)
        {
            tbNguoiDung nd = Session["NguoiDung"] as tbNguoiDung;
            string makhaucu = f["matkhaucu"].ToString();
            string matkhaumoi = f["matkhaumoi"].ToString();
            string nhaplaimk = f["nhaplaimatkhau"].ToString();
            if(nd != null)
            {
                if(matkhaumoi == nhaplaimk)
                {
                    nd.MatKhauNguoiDung = matkhaumoi;
                    dt.SaveChanges();                    
                }
            }           
            return View();
        }
    }
}