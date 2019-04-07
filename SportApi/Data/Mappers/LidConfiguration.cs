using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class LidConfiguration : IEntityTypeConfiguration<Lid>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Lid> builder)
        {
            builder.ToTable("Leden");
            builder.HasMany(t => t.LessenVanLid).WithOne();

            builder.Ignore(t => t.LessenVanLid);
        }

        #endregion Methods
    }
}