using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class GebruikerSessieConfiguration : IEntityTypeConfiguration<GebruikerSessie>
    {
        public void Configure(EntityTypeBuilder<GebruikerSessie> builder)
        {
            builder.ToTable("GebruikerSessie");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
        }
    }
}