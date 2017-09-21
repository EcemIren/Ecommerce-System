using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ETicaret.Models.Mapping
{
    public class ResimMap : EntityTypeConfiguration<Resim>
    {
        public ResimMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.BuyukYol)
                .HasMaxLength(250);

            this.Property(t => t.OrtaYol)
                .HasMaxLength(250);

            this.Property(t => t.KucukYol)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Resim");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.BuyukYol).HasColumnName("BuyukYol");
            this.Property(t => t.OrtaYol).HasColumnName("OrtaYol");
            this.Property(t => t.KucukYol).HasColumnName("KucukYol");
            this.Property(t => t.Varsayılan).HasColumnName("Varsayılan");
            this.Property(t => t.SıraNo).HasColumnName("SıraNo");
            this.Property(t => t.UrunID).HasColumnName("UrunID");

            // Relationships
            this.HasOptional(t => t.Urun)
                .WithMany(t => t.Resims)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
