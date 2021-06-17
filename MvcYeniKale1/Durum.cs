namespace MvcYeniKale1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Durum")]
    public partial class Durum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Durum()
        {
            Cari = new HashSet<Cari>();
        }

        public byte DurumID { get; set; }

        [Required]
        [StringLength(7)]
        public string Durumlar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cari> Cari { get; set; }
    }
}
