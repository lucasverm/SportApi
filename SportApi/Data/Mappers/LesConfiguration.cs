using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class LesConfiguration : IEntityTypeConfiguration<Les>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Les> builder)
        {
            builder.Ignore(t => t.Id);
            builder.ToTable("Lessen");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.HasMany(t => t.LedenVoorLes).WithOne();
            builder.Ignore(t => t.LedenVoorLes);

        }

        #endregion Methods
    }
}