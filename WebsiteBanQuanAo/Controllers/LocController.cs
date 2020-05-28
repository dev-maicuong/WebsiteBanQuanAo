using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;
using PagedList;
using PagedList.Mvc;

namespace WebsiteBanQuanAo.Controllers
{
    public class LocController : Controller
    {
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        // GET: Loc
        public PartialViewResult DanhMucNu()
        {
            return PartialView(dt.tbDanhMucs.ToList());
        }
        public PartialViewResult DanhMucNam()
        {
            return PartialView(dt.tbDanhMucs.ToList());
        }
        public ActionResult LocTheoDanhMuc(int? madanhmuc, int? page)
        {            

            return View(dt.tbSanPhams.Where(n=>n.MaDanhMuc == madanhmuc).OrderByDescending(n=>n.NgayTao).ToPagedList(page ?? 1, 8));
        }
    }
}