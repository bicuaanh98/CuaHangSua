namespace CuaHangSua.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sua")]
    public partial class Sua
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sua()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int SuaID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSua { get; set; }

        public int ThuongHieuID { get; set; }

        [Required]
        public string CachSuDung { get; set; }

        [Required]
        public string BaoQuan { get; set; }

        [Required]
        public string ThanhPhan { get; set; }

        public double DonGia { get; set; }

        public double KhoiLuong { get; set; }

        [Required]
        [StringLength(10)]
        public string DonViTInh { get; set; }

        public int? LoID { get; set; }

        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual Lo Lo { get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
