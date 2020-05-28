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
    public class HomeController : Controller
    {
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult register()
        {
            return View();
        }
        public ActionResult checkout()
        {
            return View();
        }
        public ActionResult TatCaSanPham(int ? page)
        {
            int size = 16;
            int number = (page ?? 1);
            return View(dt.tbSanPhams.OrderByDescending(n=>n.NgayTao).ToPagedList(number,size));
        }
        public ActionResult DoNam(int ? page)
        {
            int size = 8;
            int number = (page ?? 1);
            return View(dt.tbSanPhams.Where(n=>n.GioiTinh==0).OrderByDescending(n=>n.NgayTao).ToPagedList(number,size));
        }
        public ActionResult DoNu( int ? page)
        {
            int size = 8;
            int number = (page ?? 1);
            return View(dt.tbSanPhams.Where(n=>n.GioiTinh==1).OrderByDescending(n=>n.NgayTao).ToPagedList(number,size));
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}