using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class RaadplegingConfiguration : IEntityTypeConfiguration<Raadpleging>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Raadpleging> builder)
        {
            builder.ToTable("Raadplegingen");
            builder.HasKey(t => new { t.Datum, t.TijdStip });
            builder.HasOne(t => t.Lid).WithMany().IsRequired();
        }

        #endregion Methods
    }
}