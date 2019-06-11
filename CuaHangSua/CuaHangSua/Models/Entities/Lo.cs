namespace CuaHangSua.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lo")]
    public partial class Lo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lo()
        {
            Suas = new HashSet<Sua>();
        }

        public int LoID { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySanXuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime HanSuDung { get; set; }

        [StringLength(50)]
        public string NoiSanXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sua> Suas { get; set; }
    }
}
