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
    public class HienThiAoController : Controller
     
    {
        // GET: HienThiAo
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult HienThiAo(int ? page)
        {
            int size = 16;
            int number = (page ?? 1);
            return View(dt.tbSanPhams.Where(n=>n.LoaiSanPham == false).OrderByDescending(n=>n.NgayTao).ToPagedList(number,size));
        }
    }
}