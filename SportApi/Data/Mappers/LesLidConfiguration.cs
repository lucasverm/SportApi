using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class LesLidConfiguration : IEntityTypeConfiguration<LesLid>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<LesLid> builder)
        {

            builder.ToTable("LesLid");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
        }
        #endregion Methods
    }
}