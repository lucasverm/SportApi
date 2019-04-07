using Microsoft.EntityFrameworkCore;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Gebruiker> builder)
        {
            builder.ToTable("Gebruikers");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.HasMany(t => t.Sessies).WithOne();
            builder.Ignore(t => t.Sessies);
        }
    }
}