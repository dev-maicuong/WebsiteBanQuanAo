using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class TaoTaiKhoanController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaoTaiKhoan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection f, [Bind(Include = "MaNguoiDung,TaiKhoanNguoiDung,MatKhauNguoiDung,TenNguoiDung,DiaChiNguoiDung,SDTNguoiDung,GioiTinhNguoiDung")] tbNguoiDung tbNguoiDung)
        {          
            String nhaplaimatkhau = f["NhapLaiMatKhau"].ToString();
            String matkhau = f["MatKhauNguoiDung"].ToString();
            if(matkhau == nhaplaimatkhau)
            {
                if (ModelState.IsValid)
                {
                    tbNguoiDung.Token = Guid.NewGuid().ToString();
                    db.tbNguoiDungs.Add(tbNguoiDung);
                    db.SaveChanges();
                    return Redirect("/DangNhap/DangNhap");
                }
            }
            else
            {
                ViewBag.SaiMatKhauNhapLai= "Sai mật khẩu nhập lại" ;
            }
            return View(tbNguoiDung);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
