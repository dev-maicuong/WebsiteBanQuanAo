using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class DoiMatKhauKhachHangController : Controller
    {
        // GET: DoiMatKhauKhachHang    
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult DoiMatKhauKhachHang(int? id)
        {
            tbNguoiDung nd = (tbNguoiDung)Session["NguoiDung"];
            if(nd!= null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbNguoiDung tbNguoiDung = dt.tbNguoiDungs.Find(id);
                if (tbNguoiDung == null)
                {
                    return HttpNotFound();
                }
                return View(tbNguoiDung);
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhauKhachHang([Bind(Include = "MaNguoiDung,TaiKhoanNguoiDung,MatKhauNguoiDung,TenNguoiDung,DiaChiNguoiDung,SDTNguoiDung,GioiTinhNguoiDung")] tbNguoiDung tbNguoiDung,FormCollection f)
        {
            tbNguoiDung nd = (tbNguoiDung)Session["NguoiDung"];
            String nlmk = f["NhapLai"].ToString();
            String mkc = f["cu"].ToString();
            if (tbNguoiDung.MatKhauNguoiDung != nlmk)
            {
                ViewBag.ThongBao = "<div class='alert alert-danger'>Mat khau ko trung</div>";
            }
            else if(mkc != nd.MatKhauNguoiDung)
            {
                ViewBag.ThongBao = "<div class='alert alert-danger'>Mat khau cu ko dug</div>";
            }
            else
            {
                dt.Entry(tbNguoiDung).State = EntityState.Modified;
                tbNguoiDung.TaiKhoanNguoiDung = nd.TaiKhoanNguoiDung;
                tbNguoiDung.TenNguoiDung = nd.TenNguoiDung;
                tbNguoiDung.DiaChiNguoiDung = nd.DiaChiNguoiDung;
                tbNguoiDung.SDTNguoiDung = nd.SDTNguoiDung;
                tbNguoiDung.GioiTinhNguoiDung = nd.GioiTinhNguoiDung;
                dt.SaveChanges();
                return Redirect("/Home/Index");
            }
            return View(tbNguoiDung);
        }
    }
}