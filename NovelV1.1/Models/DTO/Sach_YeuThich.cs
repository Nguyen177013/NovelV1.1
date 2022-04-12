namespace NovelV1._1.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sach_YeuThich
    {
        [Key]
        public int Sach_YeuThich_ma { get; set; }

        public int? Sach_ma { get; set; }

        public int? TaiKhoan_ma { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
