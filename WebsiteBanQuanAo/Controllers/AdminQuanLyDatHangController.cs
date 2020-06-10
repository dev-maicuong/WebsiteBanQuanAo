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
    public class AdminQuanLyDatHangController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: AdminQuanLyDatHang
        public ActionResult Index()
        {
            var cTDatHangs = db.CTDatHangs.Include(c => c.tbSanPham).Include(c => c.ThongTinThanhToan);
            return View(cTDatHangs.ToList());
        }

        // GET: AdminQuanLyDatHang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDatHang cTDatHang = db.CTDatHangs.Find(id);
            if (cTDatHang == null)
            {
                return HttpNotFound();
            }
            return View(cTDatHang);
        }

        // GET: AdminQuanLyDatHang/Create
        public ActionResult Create()
        {
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham");
            ViewBag.MaTTTT = new SelectList(db.ThongTinThanhToans, "MaTTTT", "TenNguoiDung");
            return View();
        }

        // POST: AdminQuanLyDatHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTDatHang,MaSanPham,MaTTTT")] CTDatHang cTDatHang)
        {
            if (ModelState.IsValid)
            {
                db.CTDatHangs.Add(cTDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", cTDatHang.MaSanPham);
            ViewBag.MaTTTT = new SelectList(db.ThongTinThanhToans, "MaTTTT", "TenNguoiDung", cTDatHang.MaTTTT);
            return View(cTDatHang);
        }

        // GET: AdminQuanLyDatHang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDatHang cTDatHang = db.CTDatHangs.Find(id);
            if (cTDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", cTDatHang.MaSanPham);
            ViewBag.MaTTTT = new SelectList(db.ThongTinThanhToans, "MaTTTT", "TenNguoiDung", cTDatHang.MaTTTT);
            return View(cTDatHang);
        }

        // POST: AdminQuanLyDatHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTDatHang,MaSanPham,MaTTTT")] CTDatHang cTDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", cTDatHang.MaSanPham);
            ViewBag.MaTTTT = new SelectList(db.ThongTinThanhToans, "MaTTTT", "TenNguoiDung", cTDatHang.MaTTTT);
            return View(cTDatHang);
        }

        // GET: AdminQuanLyDatHang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTDatHang cTDatHang = db.CTDatHangs.Find(id);
            if (cTDatHang == null)
            {
                return HttpNotFound();
            }
            return View(cTDatHang);
        }

        // POST: AdminQuanLyDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTDatHang cTDatHang = db.CTDatHangs.Find(id);
            db.CTDatHangs.Remove(cTDatHang);
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
