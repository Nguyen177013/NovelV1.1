namespace NovelV1._1.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int HoaDon_ma { get; set; }

        public int? NoiDungSach_ma { get; set; }

        public int? TaiKhoan_ma { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HoaDon_ngay { get; set; }

        public virtual ctThanhToan ctThanhToan { get; set; }

        public virtual NoiDungSach NoiDungSach { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
