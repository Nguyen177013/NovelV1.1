namespace NovelV1._1.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ctThanhToan")]
    public partial class ctThanhToan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HoaDon_ma { get; set; }

        public decimal? ctThanhToan_tien { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
