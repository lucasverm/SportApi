using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class LesmateriaalConfiguration : IEntityTypeConfiguration<Lesmateriaal>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Lesmateriaal> builder)
        {
            builder.ToTable("Lesmaterialen");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.HasMany(t => t.Raadplegingen).WithOne();
            builder.Ignore(t => t.Raadplegingen);
            builder.HasMany(t => t.Commentaren).WithOne().HasForeignKey(l => l.Id);
            builder.Ignore(t => t.Commentaren);
            builder.HasMany(t => t.Afbeeldingen).WithOne().HasForeignKey(l => l.LesmateriaalId);
            builder.Ignore(t => t.Afbeeldingen);
            builder.HasMany(t => t.Videos).WithOne().HasForeignKey(l => l.LesmateriaalId);
            builder.Ignore(t => t.Videos);
        }

        #endregion Methods
    }
}