using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class AdminDangXuatController : Controller
    {
        // GET: AdminDangXuat
        public ActionResult Index()
        {
            Session["Admin"] = null;
            return Redirect("/DangNhap/DangNhap");
        }
    }
}