namespace NovelV1._1.Models.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoiDungSach")]
    public partial class NoiDungSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NoiDungSach()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int NoiDungSach_ma { get; set; }

        public int? Sach_ma { get; set; }

        [Required]
        public int? NoiDungSach_Tap { get; set; }

        [Required]
        public string NoiDungSach_NoiDung { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime? NoiDungSach_ngayUp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
