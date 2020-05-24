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
            int size = 8;
            int number = (page ?? 1);
            return View(dt.tbSanPhams.OrderByDescending(n=>n.NgayTao).ToPagedList(number,size));
        }
        // Đồ nữ -----------------
        // Áo nữ
        public ActionResult AoKhoacNu( int ? page)
        {
            int size = 8;
            int number = (page ?? 1);
            return View( dt.tbSanPhams.OrderByDescending(n=> n.NgayTao).ToPagedList(number,size));
        }
        public ActionResult AoHoodiNu(int ? page)
        {
            int size = 8;
            int number = (page ?? 1);
            return View(dt.tbSanPhams.OrderByDescending(n=>n.NgayTao).ToPagedList(number,size));
        }
        public ActionResult AoLenNu(int ? page)
        {
            int size = 8;
            int number = (page ?? 1);
            return View( dt.tbSanPhams.OrderByDescending(n=>n.NgayTao).ToPagedList(number,size));
        }
        public ActionResult AoSoMiNu()
        {
            return View();
        }
        public ActionResult AoThunNu()
        {
            return View();
        }
        public ActionResult Ao2DayNu()
        {
            return View();
        }
        // Quần nữ
        public ActionResult QuanDaiNu()
        {
            return View();
        }
        public ActionResult QuanBoNu()
        {
            return View();
        }
        public ActionResult QuanJeanNu()
        {
            return View();
        }
        public ActionResult ChanVay()
        {
            return View();
        }
        public ActionResult QuanShortNu()
        {
            return View();
        }
        // -----------------------------------------------
        //Đồ nam
        // Áo nam
        public ActionResult AoThunNam()
        {
            return View();
        }
        public ActionResult AoSoMiNam()
        {
            return View();
        }
        public ActionResult AoKhoacNam()
        {
            return View();
        }
        public ActionResult AoHoodiNam()
        {
            return View();
        }
        public ActionResult AoTrumDauNam()
        {
            return View();
        }
        public ActionResult AoPolo()
        {
            return View();
        }
        // Quần nam
        public ActionResult QuanJeanNam()
        {
            return View();
        }
        public ActionResult QuanDaiNam()
        {
            return View();
        }
        public ActionResult QuanShortNam()
        {
            return View();
        }
        public ActionResult QuanTayNam()
        {
            return View();
        }
        public ActionResult QuanBoiNam()
        {
            return View();
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