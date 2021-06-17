namespace MvcYeniKale1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cari")]
    public partial class Cari
    {
        public int CariID { get; set; }

        public int KisiID { get; set; }

        public byte? DurumID { get; set; }

        public decimal? Tutar { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public virtual Durum Durum { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
