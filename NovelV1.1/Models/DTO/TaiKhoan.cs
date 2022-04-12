namespace NovelV1._1.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            HoaDons = new HashSet<HoaDon>();
            Sach_YeuThich = new HashSet<Sach_YeuThich>();
        }

        [Key]
        public int TaiKhoan_ma { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để tên đăng nhập trống")]
        [Display(Name = "Account")]
        public string TaiKhoan_tenDN { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được để tên hiển thị trống")]
        [Display(Name = "Display User")]
        public string TaiKhoan_hoTen { get; set; }

        [StringLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Không được để mật khẩu trống")]
        public string TaiKhoan_matKhau { get; set; }




        [StringLength(55)]
        [Required(ErrorMessage = "Không được để Email trống")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]  
        public string TaiKhoan_email { get; set; }


        public decimal? TaiKhoan_tien { get; set; }
        [NotMapped]
        [StringLength(50)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Không được để mật xác nhận trống")]
        [Compare("TaiKhoan_matKhau", ErrorMessage = "Mật khẩu xác nhận không trùng khớp!!, Vui lòng nhập lại")]
        public string TaiKhoan_MatKhauXacNhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach_YeuThich> Sach_YeuThich { get; set; }
    }
}
