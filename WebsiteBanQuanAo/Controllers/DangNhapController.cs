﻿using System;
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
            tbNguoiDung nd; 
            String taikhoan = f["Email"].ToString();
            String matkhau = f["Password"].ToString();            
             nd = dt.tbNguoiDungs.SingleOrDefault(n => n.TaiKhoanNguoiDung == taikhoan && n.MatKhauNguoiDung == matkhau);
            tbAdmin admin = dt.tbAdmins.SingleOrDefault(n => n.TaiKhoanAdmin == taikhoan && n.MatKhauAdmin == matkhau);
            if(admin != null)
            {
                Session["Admin"] = admin;
                return Redirect("/Admin/IndexAdmin");
            }
            if (nd != null)
            {
                Session["NguoiDung"] = nd;
                Session["MaNguoiDung"] = nd.MaNguoiDung;
                return Redirect("/Home/Index");
            }
            if(taikhoan == null)
            {
                ViewBag.taikhoan = "Chưa nhập tài khoản";
            }
            if(matkhau == null)
            {
                ViewBag.matkhau = "Chưa nhập mật khẩu";
            }
            if(taikhoan == null && matkhau == null)
            {
                ViewBag.taikhoanmatkhau = "Chưa nhập tài khoản và mật khẩu";
            }
            else
            {
                ViewBag.sai = "Sai tài khoản hoặc mật khẩu";
            }
            return View();
        }
    }
}