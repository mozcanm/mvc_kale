using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MvcYeniKale1
{
    public partial class KaleMobilya : DbContext
    {
        public KaleMobilya()
            : base("name=KaleMobilya")
        {
        }

        public virtual DbSet<Cari> Cari { get; set; }
        public virtual DbSet<Durum> Durum { get; set; }
        public virtual DbSet<Kisi> Kisi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cari>()
                .Property(e => e.Tutar)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Kisi>()
                .HasMany(e => e.Cari)
                .WithRequired(e => e.Kisi)
                .WillCascadeOnDelete(false);
        }
    }
}
