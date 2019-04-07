using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class AfbeeldingConfiguration : IEntityTypeConfiguration<Afbeelding>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Afbeelding> builder)
        {
            builder.ToTable("Afbeeldingen");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
        }

        #endregion Methods
    }
}