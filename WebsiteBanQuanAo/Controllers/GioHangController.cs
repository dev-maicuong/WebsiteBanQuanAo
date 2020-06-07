using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult GioHang()
        {
            List<ClassGioHangTamThoi> GioHangTamThoi = Session["GioHangTamThoi"] as List<ClassGioHangTamThoi>;
            return View(GioHangTamThoi);
        }
        public ActionResult ThemVaoGioHang( int ? masanpham)
        {
            
            if (Session["GioHangTamThoi"]== null)
            {
                Session["GioHangTamThoi"] = new List<ClassGioHangTamThoi>();
                Session["Dem"] = "Trống";
            }
            List<ClassGioHangTamThoi> GioHangTamThoi = Session["GioHangTamThoi"] as List<ClassGioHangTamThoi>;
            if (GioHangTamThoi.FirstOrDefault(n=>n.MaSanPham == masanpham)== null)
            {
                tbSanPham sanpham = dt.tbSanPhams.Find(masanpham);
                if(Session["Dem"].ToString()=="Trống")
                {
                    Session["Dem"] = "0";
                }
                Session["Dem"] = Int32.Parse(Session["Dem"].ToString()) + 1;
                ClassGioHangTamThoi item = new ClassGioHangTamThoi()
                {
                    MaSanPham = sanpham.MaSanPham,
                    TenSanPham = sanpham.TenSanPham,
                    SoLuong=1,
                    GiaSanPham = decimal.ToInt32(sanpham.GiaSanPham.Value)
                };
                GioHangTamThoi.Add(item);
            }
            else
            {
                ClassGioHangTamThoi gio = GioHangTamThoi.FirstOrDefault(n => n.MaSanPham == masanpham);
                gio.SoLuong++;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult CapNhat( int masanpham , int soluongmoi)
        {
            List<ClassGioHangTamThoi> giohangtamthoi = Session["GioHangTamThoi"] as List<ClassGioHangTamThoi>;
            ClassGioHangTamThoi capnhat = giohangtamthoi.FirstOrDefault(n => n.MaSanPham == masanpham);
            if (capnhat !=null)
            {
                capnhat.SoLuong = soluongmoi;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Xoa( int masanpham)
        {
            List<ClassGioHangTamThoi> giohangtamthoi = Session["GioHangTamThoi"] as List<ClassGioHangTamThoi>;
            if(giohangtamthoi.FirstOrDefault(n=>n.MaSanPham ==masanpham) != null)
            {
                giohangtamthoi.Remove(giohangtamthoi.FirstOrDefault(n => n.MaSanPham == masanpham));
                Session["Dem"] = Int32.Parse(Session["Dem"].ToString()) - 1;
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public PartialViewResult GioHangKeThua()
        {
            List<ClassGioHangTamThoi> GioHangTamThoi = Session["GioHangTamThoi"] as List<ClassGioHangTamThoi>;
            return PartialView(GioHangTamThoi);
        }
    }
}