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
    public class ThongTinThanhToansController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: ThongTinThanhToans
        public ActionResult Index()
        {
            var thongTinThanhToans = db.ThongTinThanhToans.Include(t => t.tbNguoiDung);
            return View(thongTinThanhToans.ToList());
        }

        // GET: ThongTinThanhToans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinThanhToan thongTinThanhToan = db.ThongTinThanhToans.Find(id);
            if (thongTinThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thongTinThanhToan);
        }

        // GET: ThongTinThanhToans/Create
        public ActionResult Create()
        {
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung");
            return View();
        }

        // POST: ThongTinThanhToans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTTTT,MaNguoiDung,TenNguoiDung,DiaChiNguoiDung,SDTNguoiDung,GioiTinhNguoiDung,SoLuong,TongTien,TaiKhoanNguoiDung,NgayNhanSanPham")] ThongTinThanhToan thongTinThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.ThongTinThanhToans.Add(thongTinThanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", thongTinThanhToan.MaNguoiDung);
            return View(thongTinThanhToan);
        }

        // GET: ThongTinThanhToans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinThanhToan thongTinThanhToan = db.ThongTinThanhToans.Find(id);
            if (thongTinThanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", thongTinThanhToan.MaNguoiDung);
            return View(thongTinThanhToan);
        }

        // POST: ThongTinThanhToans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTTTT,MaNguoiDung,TenNguoiDung,DiaChiNguoiDung,SDTNguoiDung,GioiTinhNguoiDung,SoLuong,TongTien,TaiKhoanNguoiDung,NgayNhanSanPham")] ThongTinThanhToan thongTinThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTinThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", thongTinThanhToan.MaNguoiDung);
            return View(thongTinThanhToan);
        }

        // GET: ThongTinThanhToans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTinThanhToan thongTinThanhToan = db.ThongTinThanhToans.Find(id);
            if (thongTinThanhToan == null)
            {
                return HttpNotFound();
            }
            return View(thongTinThanhToan);
        }

        // POST: ThongTinThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTinThanhToan thongTinThanhToan = db.ThongTinThanhToans.Find(id);
            db.ThongTinThanhToans.Remove(thongTinThanhToan);
            db.SaveChanges();
            return RedirectToAction("Index");
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
