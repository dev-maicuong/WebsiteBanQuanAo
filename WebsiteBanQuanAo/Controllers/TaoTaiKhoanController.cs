﻿using System;
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

        // GET: TaoTaiKhoan
        public ActionResult Index()
        {
            return View(db.tbNguoiDungs.ToList());
        }

        // GET: TaoTaiKhoan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
            if (tbNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tbNguoiDung);
        }

        // GET: TaoTaiKhoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaoTaiKhoan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguoiDung,TaiKhoanNguoiDung,MatKhauNguoiDung,TenNguoiDung")] tbNguoiDung tbNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.tbNguoiDungs.Add(tbNguoiDung);
                db.SaveChanges();
                return Redirect("/DangNhap/DangNhap");
            }

            return View(tbNguoiDung);
        }

        // GET: TaoTaiKhoan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
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
        public ActionResult Edit([Bind(Include = "MaNguoiDung,TaiKhoanNguoiDung,MatKhauNguoiDung,TenNguoiDung")] tbNguoiDung tbNguoiDung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbNguoiDung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbNguoiDung);
        }

        // GET: TaoTaiKhoan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
            if (tbNguoiDung == null)
            {
                return HttpNotFound();
            }
            return View(tbNguoiDung);
        }

        // POST: TaoTaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbNguoiDung tbNguoiDung = db.tbNguoiDungs.Find(id);
            db.tbNguoiDungs.Remove(tbNguoiDung);
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