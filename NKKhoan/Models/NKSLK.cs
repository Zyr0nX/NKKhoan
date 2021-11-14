namespace NKKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NKSLK")]
    public partial class NKSLK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NKSLK()
        {
            ChiTietCongViec = new HashSet<ChiTietCongViec>();
            ChiTietNhanCongKhoan = new HashSet<ChiTietNhanCongKhoan>();
        }

        [Key]
        [Display(Name ="Mã khoán")]
        public int MaNKSLK { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày thực hiện")]
        [Required(ErrorMessage = "Vui lòng nhập ngày thực hiện khoán")]
        public DateTime NgayThucHienKhoan { get; set; }

        [Column(TypeName = "time")]
        [Display(Name = "Giờ bắt đầu")]
        [Required(ErrorMessage = "Vui lòng nhập giờ bắt đầu")]
        public TimeSpan? GioBatDau { get; set; }

        [Column(TypeName = "time")]
        [Display(Name = "Giờ kết thúc")]
        [Required(ErrorMessage = "Vui lòng nhập giờ kết thúc")]
        public TimeSpan? GioKetThuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]


        public virtual ICollection<ChiTietCongViec> ChiTietCongViec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietNhanCongKhoan> ChiTietNhanCongKhoan { get; set; }
    }
}
