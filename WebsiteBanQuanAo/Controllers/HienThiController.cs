using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;
namespace WebsiteBanQuanAo.Controllers
{
    public class HienThiController : Controller
    {
        // GET: HienThi
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public PartialViewResult Menu()
        {
            return PartialView(dt.tbSanPhams.Where(n=>n.LuongMua>800).ToList());
        }
        public PartialViewResult SanPhamMoiNhat()
        {
            return PartialView(dt.tbSanPhams.ToList());
        }
    }
}