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
    public class AdminQuanLyController : Controller
    {
        private DatabaseBanQuanAoEntities db = new DatabaseBanQuanAoEntities();

        // GET: AdminQuanLy
        public ActionResult Index()
        {
            return View(db.tbAdmins.ToList());
        }

        // GET: AdminQuanLy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAdmin tbAdmin = db.tbAdmins.Find(id);
            if (tbAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tbAdmin);
        }

        // GET: AdminQuanLy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminQuanLy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaAdmin,TaiKhoanAdmin,MatKhauAdmin")] tbAdmin tbAdmin)
        {
            if (ModelState.IsValid)
            {
                db.tbAdmins.Add(tbAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbAdmin);
        }

        // GET: AdminQuanLy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAdmin tbAdmin = db.tbAdmins.Find(id);
            if (tbAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tbAdmin);
        }

        // POST: AdminQuanLy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaAdmin,TaiKhoanAdmin,MatKhauAdmin")] tbAdmin tbAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbAdmin);
        }

        // GET: AdminQuanLy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAdmin tbAdmin = db.tbAdmins.Find(id);
            if (tbAdmin == null)
            {
                return HttpNotFound();
            }
            return View(tbAdmin);
        }

        // POST: AdminQuanLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbAdmin tbAdmin = db.tbAdmins.Find(id);
            db.tbAdmins.Remove(tbAdmin);
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
