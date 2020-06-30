using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebsiteBanQuanAo.Models;

namespace WebsiteBanQuanAo.Controllers
{
    public class QuenMatKhauController : Controller
    {
        // GET: QuenMatKhau
        DatabaseBanQuanAoEntities dt = new DatabaseBanQuanAoEntities();
        public ActionResult QuenMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GuiEmail(ClassQuenMatKhau quenmk)
        {

            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";//Máy chủ gmail.
                WebMail.SmtpPort = 587; // Cổng
                WebMail.SmtpUseDefaultCredentials = true;
                //Gửi gmail với giao thức bảo mật.
                WebMail.EnableSsl = true;
                //Tài khoản dùng để đăng nhập vào gmail để gửi.
                WebMail.UserName = "cuongembaubang@gmail.com";
                WebMail.Password = "trung2010203";
                // Nội dung gửi.
                WebMail.From = "cuongembaubang@gmail.com";
                tbNguoiDung nd = dt.tbNguoiDungs.SingleOrDefault(n => n.TaiKhoanNguoiDung == quenmk.EmailNhan);
                quenmk.ChuDe = "Xác nhận mật khẩu Web ";
                quenmk.NoiDung = "Xác Nhận: http://luxury2.somee.com/QuenMatKhau/ThayDoiMatKhau?id=" + nd.MaNguoiDung + "&Token=" + nd.Token;
                //Gửi gmail.
                WebMail.Send(to: quenmk.EmailNhan, subject: quenmk.ChuDe, body: quenmk.NoiDung, isBodyHtml: true);
                ViewBag.thongbao = "Gmail được gửi thành công";
            }
            catch (Exception)
            {
                ViewBag.thongbao = "mất mạng";
            }
            return Redirect("/Home/Index");
        }
        public ActionResult ThayDoiMatKhau(int? id, string Token)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbNguoiDung nd = dt.tbNguoiDungs.Find(id);
            if (Token != nd.Token)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(nd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThayDoiMatKhau(String mkmoi, String xnmk, int? id)
        {
            if (mkmoi != xnmk)
            {
                ViewBag.thong = "sai nhập lại";
                return View();
            }
            else
            {
                dt.tbNguoiDungs.Find(id).MatKhauNguoiDung = mkmoi;
                dt.tbNguoiDungs.Find(id).Token = Guid.NewGuid().ToString();
                dt.SaveChanges();
                return Redirect("/Home/Index");
            }
        }
    }
}