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
    public class HienThiController : Controller
    {
        // GET: HienThi
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public PartialViewResult Menu()
        {
            return PartialView(dt.tbDanhMucs.ToList());
        }
        public PartialViewResult SanPhamMoiNhat()
        {
            return PartialView(dt.tbSanPhams.ToList());
        }
        public PartialViewResult TatCaSanPham(int ? page)
        {
            int size = 6;
            int number = (page ?? 1);
            return PartialView(dt.tbSanPhams.OrderByDescending(n=>n.NgayTao).ToPagedList(number,size));
        }
    }
}