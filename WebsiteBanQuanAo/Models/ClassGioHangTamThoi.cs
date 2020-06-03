using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteBanQuanAo.Models
{
    public class ClassGioHangTamThoi
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string AnhMatTruoc { get; set; }
        public string AnhMatSau { get; set; }
        public string KichThuocSanPham { get; set; }
        public int LuotXem { get; set; }
        public int GiaSanPham { get; set; }
        public bool Sale { get; set; }
        public int GioiTinh { get; set; }
        public string MoTaSanPham { get; set; }
        public int MaDanhMuc { get; set; }
        public DateTime NgayTao { get; set; }
        public int GiaKhuyenMai { get; set; }
        public string SanPhamMoiorCu { get; set; }
        public int LuongMua { get; set; }
        public bool LoaiSanPham { get; set; }
        public virtual tbDanhMuc tbDanhMuc { get; set;}
        public int SoLuong { get; set;}
        public int DonGia { get { return SoLuong * GiaSanPham; } }
    }
}