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
    public class AdminQuanLyTraLoiController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: AdminQuanLyTraLoi
        public ActionResult Index()
        {
            var traLoiBinhLuans = db.TraLoiBinhLuans.Include(t => t.BinhLuan).Include(t => t.tbNguoiDung);
            return View(traLoiBinhLuans.ToList());
        }

        // GET: AdminQuanLyTraLoi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraLoiBinhLuan traLoiBinhLuan = db.TraLoiBinhLuans.Find(id);
            if (traLoiBinhLuan == null)
            {
                return HttpNotFound();
            }
            return View(traLoiBinhLuan);
        }

        // GET: AdminQuanLyTraLoi/Create
        public ActionResult Create()
        {
            ViewBag.MaBinhLuan = new SelectList(db.BinhLuans, "MaBinhLuan", "NoiDungBinhLuan");
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung");
            return View();
        }

        // POST: AdminQuanLyTraLoi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTraLoiBinhLuan,MaBinhLuan,MaNguoiDung,NoiDungTraLoi,NgayTraLoi")] TraLoiBinhLuan traLoiBinhLuan)
        {
            if (ModelState.IsValid)
            {
                db.TraLoiBinhLuans.Add(traLoiBinhLuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBinhLuan = new SelectList(db.BinhLuans, "MaBinhLuan", "NoiDungBinhLuan", traLoiBinhLuan.MaBinhLuan);
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", traLoiBinhLuan.MaNguoiDung);
            return View(traLoiBinhLuan);
        }

        // GET: AdminQuanLyTraLoi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraLoiBinhLuan traLoiBinhLuan = db.TraLoiBinhLuans.Find(id);
            if (traLoiBinhLuan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBinhLuan = new SelectList(db.BinhLuans, "MaBinhLuan", "NoiDungBinhLuan", traLoiBinhLuan.MaBinhLuan);
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", traLoiBinhLuan.MaNguoiDung);
            return View(traLoiBinhLuan);
        }

        // POST: AdminQuanLyTraLoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTraLoiBinhLuan,MaBinhLuan,MaNguoiDung,NoiDungTraLoi,NgayTraLoi")] TraLoiBinhLuan traLoiBinhLuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traLoiBinhLuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBinhLuan = new SelectList(db.BinhLuans, "MaBinhLuan", "NoiDungBinhLuan", traLoiBinhLuan.MaBinhLuan);
            ViewBag.MaNguoiDung = new SelectList(db.tbNguoiDungs, "MaNguoiDung", "TaiKhoanNguoiDung", traLoiBinhLuan.MaNguoiDung);
            return View(traLoiBinhLuan);
        }

        // GET: AdminQuanLyTraLoi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TraLoiBinhLuan traLoiBinhLuan = db.TraLoiBinhLuans.Find(id);
            if (traLoiBinhLuan == null)
            {
                return HttpNotFound();
            }
            return View(traLoiBinhLuan);
        }

        // POST: AdminQuanLyTraLoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TraLoiBinhLuan traLoiBinhLuan = db.TraLoiBinhLuans.Find(id);
            db.TraLoiBinhLuans.Remove(traLoiBinhLuan);
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
