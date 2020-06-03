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
    public class tbSanPhamsController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: tbSanPhams
        public ActionResult Index()
        {
            var tbSanPhams = db.tbSanPhams.Include(t => t.tbDanhMuc);
            return View(tbSanPhams.ToList());
        }

        // GET: tbSanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSanPham tbSanPham = db.tbSanPhams.Find(id);
            if (tbSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tbSanPham);
        }

        // GET: tbSanPhams/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMuc = new SelectList(db.tbDanhMucs, "MaDanhMuc", "TenDanhMuc");
            return View();
        }

        // POST: tbSanPhams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,AnhMatTruoc,AnhMatSau,KichThuocSanPham,LuotXem,GiaSanPham,Sale,GioiTinh,MoTaSanPham,MaDanhMuc,NgayTao,GiaKhuyenMai,SanPhamMoiorCu,LuongMua,LoaiSanPham")] tbSanPham tbSanPham)
        {
            if (ModelState.IsValid)
            {
                db.tbSanPhams.Add(tbSanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDanhMuc = new SelectList(db.tbDanhMucs, "MaDanhMuc", "TenDanhMuc", tbSanPham.MaDanhMuc);
            return View(tbSanPham);
        }

        // GET: tbSanPhams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSanPham tbSanPham = db.tbSanPhams.Find(id);
            if (tbSanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDanhMuc = new SelectList(db.tbDanhMucs, "MaDanhMuc", "TenDanhMuc", tbSanPham.MaDanhMuc);
            return View(tbSanPham);
        }

        // POST: tbSanPhams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSanPham,TenSanPham,AnhMatTruoc,AnhMatSau,KichThuocSanPham,LuotXem,GiaSanPham,Sale,GioiTinh,MoTaSanPham,MaDanhMuc,NgayTao,GiaKhuyenMai,SanPhamMoiorCu,LuongMua,LoaiSanPham")] tbSanPham tbSanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbSanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDanhMuc = new SelectList(db.tbDanhMucs, "MaDanhMuc", "TenDanhMuc", tbSanPham.MaDanhMuc);
            return View(tbSanPham);
        }

        // GET: tbSanPhams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSanPham tbSanPham = db.tbSanPhams.Find(id);
            if (tbSanPham == null)
            {
                return HttpNotFound();
            }
            return View(tbSanPham);
        }

        // POST: tbSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbSanPham tbSanPham = db.tbSanPhams.Find(id);
            db.tbSanPhams.Remove(tbSanPham);
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
