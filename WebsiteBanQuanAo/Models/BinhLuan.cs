//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteBanQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BinhLuan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BinhLuan()
        {
            this.TraLoiBinhLuans = new HashSet<TraLoiBinhLuan>();
        }
    
        public int MaBinhLuan { get; set; }
        public Nullable<int> MaSanPham { get; set; }
        public Nullable<int> MaNguoiDung { get; set; }
        public string NoiDungBinhLuan { get; set; }
        public Nullable<System.DateTime> NgayDangBinhLuan { get; set; }
    
        public virtual tbNguoiDung tbNguoiDung { get; set; }
        public virtual tbSanPham tbSanPham { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraLoiBinhLuan> TraLoiBinhLuans { get; set; }
    }
}
