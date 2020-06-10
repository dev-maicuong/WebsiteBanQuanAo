using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult IndexAdmin()
        {  
            if (Session["Admin"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }
    }
}