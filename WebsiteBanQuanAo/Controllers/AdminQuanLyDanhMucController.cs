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
    public class AdminQuanLyDanhMucController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: AdminQuanLyDanhMuc
        public ActionResult Index()
        {
            return View(db.tbDanhMucs.ToList());
        }

        // GET: AdminQuanLyDanhMuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDanhMuc tbDanhMuc = db.tbDanhMucs.Find(id);
            if (tbDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(tbDanhMuc);
        }

        // GET: AdminQuanLyDanhMuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminQuanLyDanhMuc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDanhMuc,TenDanhMuc,GioiTinh,AoOrQuan")] tbDanhMuc tbDanhMuc)
        {
            if (ModelState.IsValid)
            {
                db.tbDanhMucs.Add(tbDanhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbDanhMuc);
        }

        // GET: AdminQuanLyDanhMuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDanhMuc tbDanhMuc = db.tbDanhMucs.Find(id);
            if (tbDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(tbDanhMuc);
        }

        // POST: AdminQuanLyDanhMuc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDanhMuc,TenDanhMuc,GioiTinh,AoOrQuan")] tbDanhMuc tbDanhMuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbDanhMuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbDanhMuc);
        }

        // GET: AdminQuanLyDanhMuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDanhMuc tbDanhMuc = db.tbDanhMucs.Find(id);
            if (tbDanhMuc == null)
            {
                return HttpNotFound();
            }
            return View(tbDanhMuc);
        }

        // POST: AdminQuanLyDanhMuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbDanhMuc tbDanhMuc = db.tbDanhMucs.Find(id);
            db.tbDanhMucs.Remove(tbDanhMuc);
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
