using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class BeheerderConfiguration : IEntityTypeConfiguration<Beheerder>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Beheerder> builder)
        {
            builder.ToTable("Beheerders");

        }

        #endregion Methods
    }
}