using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Models.Mapping
{
    public class OzellikTipMap : EntityTypeConfiguration<OzellikTip>
    {
        public OzellikTipMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Aciklama)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("OzellikTip");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.KategoriID).HasColumnName("KategoriID");

            // Relationships
            this.HasRequired(t => t.Kategori)
                .WithMany(t => t.OzellikTips)
                .HasForeignKey(d => d.KategoriID);

        }
    }
}
