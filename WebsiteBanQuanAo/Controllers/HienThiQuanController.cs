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
    public class HienThiQuanController : Controller
    {
        // GET: HienThiQuan
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult HienThiQuan( int ? page)
        {
            int size = 8;
            int number = (page ?? 1);
            return View(dt.tbSanPhams.Where(n=>n.LoaiSanPham == true).OrderByDescending(n => n.NgayTao).ToPagedList(number,size));
        }
    }
}