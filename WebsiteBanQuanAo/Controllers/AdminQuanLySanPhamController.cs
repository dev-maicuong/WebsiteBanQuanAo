using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class AdminQuanLySanPhamController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: AdminQuanLySanPham
        public ActionResult Index()
        {
            var tbSanPhams = db.tbSanPhams.Include(t => t.tbDanhMuc);
            return View(tbSanPhams.ToList());
        }

        // GET: AdminQuanLySanPham/Details/5
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

        // GET: AdminQuanLySanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaDanhMuc = new SelectList(db.tbDanhMucs, "MaDanhMuc", "TenDanhMuc");
            return View();
        }

        // POST: AdminQuanLySanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSanPham,TenSanPham,AnhMatTruoc,AnhMatSau,KichThuocSanPham,LuotXem,GiaSanPham,Sale,GioiTinh,MoTaSanPham,MaDanhMuc,NgayTao,GiaKhuyenMai,SanPhamMoiorCu,LuongMua,LoaiSanPham")] tbSanPham tbSanPham, HttpPostedFileBase fileUpload)
        {
            var fileimg = Path.GetFileName(fileUpload.FileName);
            //Lưu file
            var pa = Path.Combine(Server.MapPath("~/Content/LayoutAdmin/images"), fileimg);
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            else if (System.IO.File.Exists(pa))
            {
                ViewBag.ThongBao = "Hình ảnh đã tồn tại!";
            }
            else
            {
                fileUpload.SaveAs(pa);
            }
            tbSanPham.NgayTao = DateTime.Now;
            tbSanPham.LuotXem = 0;
            tbSanPham.LuongMua = 0;
            db.tbSanPhams.Add(tbSanPham);
            tbSanPham.AnhMatTruoc = fileUpload.FileName;
            db.SaveChanges();
            ViewBag.MaDanhMuc = new SelectList(db.tbDanhMucs, "MaDanhMuc", "TenDanhMuc", tbSanPham.MaDanhMuc);
            return RedirectToAction("Index");
        }

        // GET: AdminQuanLySanPham/Edit/5
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

        // POST: AdminQuanLySanPham/Edit/5
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

        // GET: AdminQuanLySanPham/Delete/5
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

        // POST: AdminQuanLySanPham/Delete/5
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
