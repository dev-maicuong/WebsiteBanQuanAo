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
    public class DoiMatKhauKhachHangController : Controller
    {
        // GET: DoiMatKhauKhachHang
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult DoiMatKhauKhachHang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNguoiDung tbNguoiDung = dt.tbNguoiDungs.Find(id);
            if (tbNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tbNguoiDung);
        }

        // POST: TaoTaiKhoan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhauKhachHang([Bind(Include = "MaNguoiDung,TaiKhoanNguoiDung,MatKhauNguoiDung,TenNguoiDung,DiaChiNguoiDung,SDTNguoiDung,GioiTinhNguoiDung")] tbNguoiDung tbNguoiDung)
        {
            if (ModelState.IsValid)
            {
                dt.Entry(tbNguoiDung).State = EntityState.Modified;
                dt.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbNguoiDung);
        }
    }
}