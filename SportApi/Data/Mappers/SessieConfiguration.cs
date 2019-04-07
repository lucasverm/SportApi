using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class SessieConfiguration : IEntityTypeConfiguration<Sessie>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Sessie> builder)
        {
            builder.ToTable("Sessies");
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasMany(t => t.Aanwezigen).WithOne();
            builder.Ignore(t => t.Aanwezigen);
        }

        #endregion Methods
    }
}