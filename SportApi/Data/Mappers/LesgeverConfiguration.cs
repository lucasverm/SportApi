using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class LesgeverConfiguration : IEntityTypeConfiguration<Lesgever>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Lesgever> builder)
        {
            builder.ToTable("Lesgevers");

        }

        #endregion Methods
    }
}