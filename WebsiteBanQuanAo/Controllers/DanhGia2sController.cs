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
    public class DanhGia2sController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: DanhGia2s
        public ActionResult Index()
        {
            var danhGias = db.DanhGias.Include(d => d.tbNguoiDung).Include(d => d.tbSanPham);
            return View(danhGias.ToList());
        }

        // GET: DanhGia2s/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }

        // GET: DanhGia2s/Create
        public ActionResult Create()
        {
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung");
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: DanhGia2s/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhGia,DanhGia1,MaNguoiDung,MaSanPham,NgayDanhGia")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                db.DanhGias.Add(danhGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", danhGia.MaNguoiDung);
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", danhGia.MaSanPham);
            return View(danhGia);
        }

        // GET: DanhGia2s/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", danhGia.MaNguoiDung);
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", danhGia.MaSanPham);
            return View(danhGia);
        }

        // POST: DanhGia2s/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhGia,DanhGia1,MaNguoiDung,MaSanPham,NgayDanhGia")] DanhGia danhGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", danhGia.MaNguoiDung);
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", danhGia.MaSanPham);
            return View(danhGia);
        }

        // GET: DanhGia2s/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhGia danhGia = db.DanhGias.Find(id);
            if (danhGia == null)
            {
                return HttpNotFound();
            }
            return View(danhGia);
        }

        // POST: DanhGia2s/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhGia danhGia = db.DanhGias.Find(id);
            db.DanhGias.Remove(danhGia);
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
