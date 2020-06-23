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
    public class AdminQuanLyTTTTController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: AdminQuanLyTTTT
        public ActionResult Index()
        {
            var thongTinThanhToans = db.ThongTinThanhToans.Include(t => t.tbNguoiDung);
            return View(thongTinThanhToans.ToList());
        }

        // GET: AdminQuanLyTTTT/Details/5
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
        // GET: AdminQuanLyTTTT/Delete/5
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

        // POST: AdminQuanLyTTTT/Delete/5
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
