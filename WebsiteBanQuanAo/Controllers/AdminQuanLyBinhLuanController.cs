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
    public class AdminQuanLyBinhLuanController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: AdminQuanLyBinhLuan
        public ActionResult Index()
        {
            var binhLuans = db.BinhLuans.Include(b => b.tbNguoiDung).Include(b => b.tbSanPham);
            return View(binhLuans.ToList());
        }

        // GET: AdminQuanLyBinhLuan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // GET: AdminQuanLyBinhLuan/Create
        public ActionResult Create()
        {
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung");
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham");
            return View();
        }

        // POST: AdminQuanLyBinhLuan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBinhLuan,MaSanPham,MaNguoiDung,NoiDungBinhLuan,NgayDangBinhLuan")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.BinhLuans.Add(binhLuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", binhLuan.MaNguoiDung);
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", binhLuan.MaSanPham);
            return View(binhLuan);
        }

        // GET: AdminQuanLyBinhLuan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", binhLuan.MaNguoiDung);
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", binhLuan.MaSanPham);
            return View(binhLuan);
        }

        // POST: AdminQuanLyBinhLuan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBinhLuan,MaSanPham,MaNguoiDung,NoiDungBinhLuan,NgayDangBinhLuan")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binhLuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", binhLuan.MaNguoiDung);
            ViewBag.MaSanPham = new SelectList(db.tbSanPhams, "MaSanPham", "TenSanPham", binhLuan.MaSanPham);
            return View(binhLuan);
        }

        // GET: AdminQuanLyBinhLuan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(id);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // POST: AdminQuanLyBinhLuan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BinhLuan binhLuan = db.BinhLuans.Find(id);
            db.BinhLuans.Remove(binhLuan);
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
