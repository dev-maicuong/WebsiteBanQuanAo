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
