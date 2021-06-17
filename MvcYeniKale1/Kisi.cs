namespace MvcYeniKale1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kisi")]
    public partial class Kisi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kisi()
        {
            Cari = new HashSet<Cari>();
        }

        public int KisiID { get; set; }

        [StringLength(31)]
        public string Ad { get; set; }

        [StringLength(35)]
        public string Firma { get; set; }

        [StringLength(15)]
        public string Tel1 { get; set; }

        [StringLength(15)]
        public string Tel2 { get; set; }

        [StringLength(100)]
        public string Adres { get; set; }

        public bool Karaliste { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cari> Cari { get; set; }
    }
}
