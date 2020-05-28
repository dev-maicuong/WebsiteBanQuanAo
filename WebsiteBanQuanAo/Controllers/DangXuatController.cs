using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanQuanAo.Controllers
{
    public class DangXuatController : Controller
    {
        // GET: DangXuat
        public ActionResult DangXuat()
        {
            Session["NguoiDung"] = null;
            return Redirect("/Home/Index");
        }
    }
}